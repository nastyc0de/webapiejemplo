using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace apiWeb.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController:ControllerBase
    {
        
        public JsonResult GetMovies(){
            return new JsonResult(MovieList.Current.Movies);
        }
    }
}