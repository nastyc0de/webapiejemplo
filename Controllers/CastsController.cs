using System.Linq;
using apiWeb;
using Microsoft.AspNetCore.Mvc;

namespace webapiejemplo.Controllers
{
    [ApiController]
    [Route("api/movies/{id}/casts")]
    public class CastsController: ControllerBase
    {
        public IActionResult GetCasts(int id){
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.Casts);
        }
        [HttpGet("{castId}")]
        public IActionResult getCast(int id, int castId)
        {
            var movie =  MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var cast = movie.Casts.FirstOrDefault(cast => cast.Id == castId);
            if (cast == null)
            {
                return NotFound();
            }
            return Ok(cast);
        }
    }
}