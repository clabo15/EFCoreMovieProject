using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreMovies_Demo_2.DTOs;
using EFCoreMovies_Demo_2.Entities;
using EFCoreMovies_Demo_2.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies_Demo_2.Controllers;
[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenresController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Returns all Genres in the database 
    [HttpGet]
    public async Task<IEnumerable<Genre>> Get()
    {
        _context.Logs.Add(new Log { Message = "Executing Get from GenresController" });
        await _context.SaveChangesAsync();
        // Async is better for IO operations
        return await _context.Genres.AsNoTracking()
            .OrderByDescending(g => EF.Property<DateTime>(g, "CreatedDate"))
            .ToListAsync();
    }

    // Returns the first Genre in the database
    [HttpGet("first")]
    public async Task<Genre> GetFirst()
    {
        return await _context.Genres.AsNoTracking().FirstAsync();
    }

    // Returns the first Genre that has the letter m
    [HttpGet("first-m")]
    public async Task<Genre> GetFirstWithFilter()
    {
        return await _context.Genres.FirstAsync(_ => _.Name.Contains("m"));
    }

    // Returns the first Genre that has the letter z or default value not found
    [HttpGet("first-z")]
    public async Task<ActionResult<Genre>> GetFirstOrDefaultWithFilter()
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(_ => _.Name.Contains("z"));
        if (genre is null)
        {
            return NotFound();
        }
        return genre;
    }

    // Filter with Where
    [HttpGet("filter")]
    public async Task<IEnumerable<Genre>> Filter(string name)
    {
        return await _context.Genres.Where(_ => _.Name.StartsWith(name)).ToListAsync();
    }

    // Get all Genres with paging ordered by name
    [HttpGet("get-paging")]
    public async Task<IEnumerable<Genre>> GetWithPaging(int page, int recordsToTake)
    {
        return await _context.Genres.AsNoTracking()
            .OrderBy(g => g.Name)
            .Paginate(page, recordsToTake)
            .ToListAsync();
    }


    // Inserting a record
    [HttpPost]
    public async Task<ActionResult> Post(GenreCreationDTO genreCreationDto)
    {
        var genreExists = await _context.Genres.AnyAsync(p => p.Name == genreCreationDto.Name);
        if (genreExists)
        {
            return BadRequest("The specified genre name already exists");
        }
        // marking the var genre with the status "added"
        // this is an operation in memory for us to add genre to the table in the future
        var genre = _mapper.Map<Genre>(genreCreationDto);
        var status1 = _context.Entry(genre).State; // Check meta data of the entity for debugging
        _context.Add(genre);
        var status2 = _context.Entry(genre).State; // Check meta data of the entity for debugging
        await _context.SaveChangesAsync();
        var status3 = _context.Entry(genre).State; // Check meta data of the entity for debugging
        return Ok();
    }
    
    // Inserting several records
    [HttpPost("several")]
    public async Task<ActionResult> Post(GenreCreationDTO[] genresDTO)
    {
        var genres = _mapper.Map<Genre[]>(genresDTO);
        _context.AddRange(genres);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("add2")]
    public async Task<ActionResult> Add2(Guid id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync();

        if (genre is null)
        {
            return NotFound();
        }

        genre.Name += " 2";
        await _context.SaveChangesAsync();
        return Ok();
    }

    // Full Delete
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        _context.Remove(genre);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // Soft Delete
    [HttpDelete("softdelete/{id:Guid}")]
    public async Task<ActionResult> SoftDelete(Guid id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        genre.IsDelete = true;
        await _context.SaveChangesAsync();
        return Ok();
       
    }

    // Soft Delete Restore
    // It ignores the query filter in the config
    [HttpPost("restore/{id:Guid}")]
    public async Task<ActionResult> Restore(Guid id)
    {
        var genre = await _context.Genres.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        genre.IsDelete = false;
        await _context.SaveChangesAsync();
        return Ok();

    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<Genre>> Get(Guid id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(p => p.Id == id);

        if (genre is null)
        {
            return NotFound();
        }

        var createdDate = _context.Entry(genre).Property<DateTime>("CreatedDate").CurrentValue;
        return Ok(new
        {
            Id = genre.Id,
            Name = genre.Name,
            createdDate = createdDate
        });
    }
}