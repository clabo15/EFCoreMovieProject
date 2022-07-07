using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies_Demo_2.DTOs;
using EFCoreMovies_Demo_2.Entities;
using EFCoreMovies_Demo_2.Entities.Keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies_Demo_2.Controllers;
[ApiController]
[Route("api/cinemas")]
public class CinemasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    

    public CinemasController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }

    // Maps the geometry type to longitude and latitude
    [HttpGet]
    public async Task<IEnumerable<CinemaDTO>> Get()
    {
        return await _context.Cinemas.ProjectTo<CinemaDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }


    // Returns cinemas closest to me
    [HttpGet("closetome")]
    public async Task<ActionResult> Get(double latitude, double longitude)
    {
        var geometry = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        var myLocation = geometry.CreatePoint(new Coordinate(longitude, latitude));

        var maxDistance = 2000;

        var cinemas = await _context.Cinemas
            .OrderBy(c => c.Location.Distance(myLocation))
            .Where(c => c.Location.IsWithinDistance(myLocation, maxDistance))
            .Select(c => new
            {
                Name = c.Name,
                Distance = Math.Round(c.Location.Distance(myLocation))
            }).ToListAsync();
        return Ok(cinemas);
    }


    // Inserting related data
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateCinemaDTO createCinemaDto)
    {
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(createCinemaDto.Longitude, createCinemaDto.Latitude));

        var cinema = new Cinema
        {
            Name = createCinemaDto.Name,
            Location = cinemaLocation,
            CinemaOffer = new CinemaOffer
            {
                DiscountPercentage = 5,
                Begin = DateTime.Today,
                End = DateTime.Today.AddDays(7)
            },
            CinemaHalls = new HashSet<CinemaHall>
            {
                new CinemaHall
                {
                    Cost = 200,
                    Currency = Currency.DominicanPeso,
                    CinemaHallType = CinemaHallType.TwoDimensions
                },
                new CinemaHall
                {
                    Cost = 250,
                    Currency = Currency.USDollar,
                    CinemaHallType = CinemaHallType.ThreeDimensions
                }
            }
        };
        _context.Add(cinema);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("fulldtomap")]
    public async Task<ActionResult> PostWithDTOMap(CreateCinemaDTO createCinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(createCinemaDto);
        _context.Add(cinema);
        await _context.SaveChangesAsync();
        return Ok();
    }
    // Bad style of doing things
    [HttpPut("cinemaOffer")]
    public async Task<ActionResult> PutCinemaOffer(CinemaOffer cinemaOffer)
    {
        _context.Update(cinemaOffer);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var cinemaDb = await _context.Cinemas
            .Include(c => c.CinemaHalls)
            .Include(c => c.CinemaOffer)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cinemaDb is null)
        {
            return NotFound();
        }

        cinemaDb.Location = null;

        return Ok(cinemaDb);
    }

    // Updating with relations
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(CreateCinemaDTO createCinemaDto, Guid id)
    {
        var cinemaDB = await _context.Cinemas
            .Include(c => c.CinemaHalls)
            .Include(c => c.CinemaOffer)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cinemaDB is null)
        {
            return NotFound();
        }

        cinemaDB = _mapper.Map(createCinemaDto, cinemaDB);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("withoutLocation")]
    public async Task<IEnumerable<CinemaWithoutLocation>> GetWithoutLocation()
    {
        //return await _context.Set<CinemaWithoutLocation>().ToListAsync();
        return await _context.CinemaWithoutLocations.ToListAsync();
    }
}