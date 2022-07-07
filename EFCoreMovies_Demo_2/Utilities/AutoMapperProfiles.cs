using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreMovies_Demo_2.DTOs;
using EFCoreMovies_Demo_2.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreMovies_Demo_2.Utilities;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Actor, ActorDTO>();
        CreateMap<Cinema, CinemaDTO>()
            .ForMember(dto => dto.Latitude, ent => ent.MapFrom(p => p.Location.Y))
            .ForMember(dto => dto.Longitude, ent => ent.MapFrom(p => p.Location.X));
        CreateMap<Genre, GenreDTO>();
        CreateMap<GenreCreationDTO, Genre>();
        CreateMap<Movie, MovieDTO>()
            .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(p => p.CinemaHallMovies.Select(c => c.CinemaHall.Cinema).OrderByDescending(g => g.Name)))
            .ForMember(dto => dto.Actors, ent => ent.MapFrom(ma => ma.MoviesActors.Select(ma => ma.Actor).OrderByDescending(a => a.Name)))
            .ForMember(dto => dto.Genres, ent => ent.MapFrom(g => g.GenreMovies.Select(gm => gm.Genre).OrderByDescending(g => g.Name)));

        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        CreateMap<CreateCinemaDTO, Cinema>().ForMember(ent => ent.Location,
            dto => dto.MapFrom(prop => geometryFactory.CreatePoint(new Coordinate(prop.Longitude, prop.Latitude))));
        CreateMap<CinemaOfferCreationDTO, CinemaOffer>();
        CreateMap<CinemaHallCreationDTO, CinemaHall>();

        CreateMap<MovieCreationDTO, Movie>()
            .ForMember(ent => ent.GenreMovies,
                dto => dto.MapFrom(prop => prop.GenresIds.Select(id => new Genre { Id = id }))).ForMember(
                ent => ent.CinemaHallMovies,
                dto => dto.MapFrom(prop => prop.CinemaHallIds.Select(id => new CinemaHall { Id = id })));

        CreateMap<MovieActorCreationDTO, MovieActor>();

        CreateMap<ActorCreationDTO, Actor>();

    }
}