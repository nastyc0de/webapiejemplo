using System.Collections.Generic;
using webapiejemplo.Entities;

namespace webapiejemplo.Services
{
    public interface IMovieInfoRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id, bool includeCast);

        IEnumerable<Cast> GetCastsByMovie(int id, bool includeCast);
        Cast GetCastByMovie(int id, int castId);
    }
}