using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace apiWeb.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController:ControllerBase
    {
        
        public IActionResult GetMovies(){
            return Ok(MovieList.Current.Movies);
        }
        // llamar aun elemento de la lista
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}