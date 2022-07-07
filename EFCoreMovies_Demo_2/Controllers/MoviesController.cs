using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Core.Internal;
using EFCoreMovies_Demo_2.DTOs;
using EFCoreMovies_Demo_2.Entities;
using EFCoreMovies_Demo_2.Entities.Keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies_Demo_2.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public readonly IMapper _mapper;
    public MoviesController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Eager loading for related data (many to many relations)
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<MovieDTO>> Get(Guid id)
    {
        var movie = await _context.Movies
            .Include(m => m.GenreMovies)
            .ThenInclude(m => m.Genre)
            .Include(m => m.CinemaHallMovies)
            .ThenInclude(ch => ch.CinemaHall.Cinema)
            .Include(m => m.MoviesActors)
            .ThenInclude(ma => ma.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie is null)
        {
            return NotFound();
        }

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

        return movieDTO;
    }

    // Eager loading for related data using filtering and ordering
    [HttpGet("filter/{id:Guid}")]
    public async Task<ActionResult<MovieDTO>> GetWithFilter(Guid id)
    {
        var movie = await _context.Movies
            .Include(m => m.GenreMovies.OrderByDescending(g => g.Genre).Where(g => g.Genre.Name.Contains("m")))
            .ThenInclude(m => m.Genre)
            .Include(m => m.CinemaHallMovies.OrderByDescending(ch => ch.CinemaHall.Cinema.Name))
            .ThenInclude(ch => ch.CinemaHall.Cinema)
            .Include(m => m.MoviesActors)
            .ThenInclude(ma => ma.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie is null)
        {
            return NotFound();
        }

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

        return movieDTO;
    }

    // Eager loading for related data using filtering and ordering
    [HttpGet("automapper/{id:Guid}")]
    public async Task<ActionResult<MovieDTO>> GetWithAutoMapper(Guid id)
    {
        var movieDTO = await _context.Movies
            .ProjectTo<MovieDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movieDTO is null)
        {
            return NotFound();
        }

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

        return movieDTO;
    }

    // Select loading via anonymous function
    [HttpGet("selectloading/{id:guid}")]
    public async Task<ActionResult> GetSelectLoading(Guid id)
    {
        // Select from movieDTO
        var movieDTO = await _context.Movies.Select(m => new
        {
            Id = m.Id,
            Title = m.Title,
            // Genres mapped to a collection of strings
            Genres = m.GenreMovies
                .Select(_ => _.Genre)
                .Select(_ => _.Name)
                .OrderByDescending(g => g).ToList()
        }).FirstOrDefaultAsync(m => m.Id == id);

        if (movieDTO is null)
        {
            return NotFound();
        }

        return Ok(movieDTO);
    }

    // ExplicitLoading
    [HttpGet("explicitLoading/{id:Guid}")]
    public async Task<ActionResult<MovieDTO>> GetExplicit(Guid id)
    {
        // Query Movie return first matching Id or default
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        // Load relational data
        var genresCount = await _context.Entry(movie).Collection(p => p.GenreMovies).Query().CountAsync();

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        return Ok(new
        {
            Id = movieDTO.Id,
            Title = movieDTO.Title,
            GenresCount = genresCount
        });
    }

    // Lazy loading -> dont do this in production it leads to the n + 1 problem in queries 
    [HttpGet("lazyloading/{id:Guid}")]
    public async Task<ActionResult<MovieDTO>> GetLazyLoading(Guid id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        var movieDTO = _mapper.Map<MovieDTO>(movie);

        movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

        return movieDTO;
    }

    // Using grouping with groupby
    [HttpGet("groupedByCinema")]
    public async Task<ActionResult> GetGroupedByCinema()
    {
        var groupedMovies = await _context.Movies.GroupBy(m => m.InCinemas).Select(g => new
        {
            InCinemas = g.Key,
            Count = g.Count(),
            Movies = g.ToList()
        }).ToListAsync();

        return Ok(groupedMovies);
    }

    // Movies grouped by genres with a count
    [HttpGet("groupByGenresCount")]
    public async Task<ActionResult> GetGroupedByGenresCount()
    {
        var groupedMovies = await _context.Movies
            .GroupBy(m => m.GenreMovies.Count)
            .Select(g => new
            {
                Count = g.Key,
                Titles = g.Select(m => m.Title),
                // Flatten the collection
                Genres = g.Select(m => m.GenreMovies)
                .SelectMany(a => a)
                .Select(ge => ge.Genre.Name)
                .Distinct()
            }).ToListAsync();

        return Ok(groupedMovies);
    }

    // Deferred Execution (not working)
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> Filter([FromQuery] MovieFilterDTO movieFilterDto)
    {
        var moviesQueryable = _context.Movies.AsQueryable();

        // If title is not null, run a where clause that contains the title
        if (!string.IsNullOrEmpty(movieFilterDto.Title))
        {
            moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(movieFilterDto.Title));
        }

        if (movieFilterDto.InCinemas)
        {
            moviesQueryable = moviesQueryable.Where(m => m.InCinemas);
        }

        if (movieFilterDto.UpcomingReleases)
        {
            var today = DateTime.Today;
            moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > today);
        }

        moviesQueryable = moviesQueryable.Where(m => m.GenreMovies.Select(g => g.Genre.Id).Contains(movieFilterDto.GenreId));

        var movies = await moviesQueryable.Include(m => m.GenreMovies).ToListAsync();
        return _mapper.Map<List<MovieDTO>>(movies);
    }

    // Not working...
    [HttpPost]
    public async Task<ActionResult> Post(MovieCreationDTO movieCreationDto)
    {
        var movie = _mapper.Map<Movie>(movieCreationDto);
        
        movie.GenreMovies.ForEach(g => _context.Entry(g).State = EntityState.Unchanged);
        movie.CinemaHallMovies.ForEach(ch => _context.Entry(ch).State = EntityState.Unchanged);

        if (!movie.MoviesActors.IsNullOrEmpty())
        {
            for (var i = 0; i < movie.MoviesActors.Count; i++)
            {
                movie.MoviesActors[i].Order = i + 1;
            }
        }

        _context.Add(movie);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("withCounts")]
    public async Task<ActionResult<IEnumerable<MovieWithCounts>>> GetWithCounts()
    {
        return await _context.Set<MovieWithCounts>().ToListAsync();
    }
}