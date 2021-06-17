using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapiejemplo.Context;
using webapiejemplo.Entities;

namespace webapiejemplo.Services
{
    public class MovieRepository : IMovieInfoRepository
    {
        private MovieInfoContext _context;
        public MovieRepository(MovieInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Cast GetCastByMovie(int id, int castId)
        {
            return _context.Casts
                    .Where(movie =>movie.Id == id && movie.Id == castId).FirstOrDefault();
        }

        public IEnumerable<Cast> GetCastsByMovie(int id, bool includeCast)
        {
            return _context.Casts
                    .Where(movie =>movie.Id == id).ToList();
        }

        public Movie GetMovie(int id, bool includeCast)
        {
            if (includeCast)
            {
                return _context.Movies.Include(c => c.Casts)
                        .Where(movie => movie.Id == id).FirstOrDefault();
            }
            return _context.Movies.Where(movie => movie.Id == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(movie => movie.Name).ToList();
        }
    }
}