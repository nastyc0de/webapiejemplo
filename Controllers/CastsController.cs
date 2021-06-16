using System;
using System.Linq;
using apiWeb;
using apiWeb.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapiejemplo.Models;

namespace webapiejemplo.Controllers
{
    [ApiController]
    [Route("api/movies/{id}/casts")]
    public class CastsController: ControllerBase
    {
        private ILogger<CastsController> _logger;
        public CastsController(ILogger<CastsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]
        public IActionResult GetCasts(int id){
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.Casts);
        }
        
        [HttpGet("{castId}", Name ="getCast")]
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
                _logger.LogInformation($"El cast con id {castId} no fue encontrado");
                return NotFound();
            }
            return Ok(cast);
        }
        
        [HttpPost]
        public IActionResult CreateCast(int id, [FromBody] NewCastDto newCastDto)
        {
            if (newCastDto.Name == newCastDto.CharName)
            {
                ModelState.AddModelError(
                    "Name",
                    "El nombre debe de ser distinto al del personaje"
                );
                return BadRequest(ModelState);
            }
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null){
                return NotFound();
            }
            var maxCastId = MovieList.Current.Movies
                .SelectMany(movie =>movie.Casts).Max(cast =>cast.Id);
            var newCast = new CastDto{
                Id = ++maxCastId,
                Name = newCastDto.Name,
                CharName = newCastDto.CharName
            };
            movie.Casts.Add(newCast);
            return CreatedAtRoute(
                nameof(getCast),
                new {id, castId = newCast.Id},
                newCastDto
            );
        }
        
        [HttpPut("{castId}") ]
        public IActionResult UpdateCast(int id, int castId, [FromBody] UpdateCastDto updateCastDto)
        {
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null){
                return NotFound();
            }
            var castFromStore = movie.Casts.FirstOrDefault(cast => cast.Id == castId);
            if (castFromStore == null){
                return NotFound();
            }
            castFromStore.Name = updateCastDto.Name;
            castFromStore.CharName = updateCastDto.CharName;
            return NoContent();
        }
        
        [HttpPatch("{castId}")]
        public IActionResult PatchCast(int id, int castId, [FromBody] JsonPatchDocument<UpdateCastDto> patchDocument)
        {
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null){
                return NotFound();
            }
            var castFromStore = movie.Casts.FirstOrDefault(cast => cast.Id == castId);
            if (castFromStore == null){
                return NotFound();
            }
            var castToPatch = new UpdateCastDto()
            {
                Name = castFromStore.Name,
                CharName = castFromStore.CharName
            };
            patchDocument.ApplyTo(castToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();   
            }
            if (!TryValidateModel(castToPatch))
            {
                return BadRequest();
            }
            castFromStore.Name = castToPatch.Name;
            castFromStore.CharName = castToPatch.CharName;
            return NoContent();
        }
        
        [HttpDelete("{castId}")]
        public IActionResult DeleteCast(int id, int castId)
        {
            var movie = MovieList.Current.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null){
                return NotFound();
            }
            var castFromStore = movie.Casts.FirstOrDefault(cast => cast.Id == castId);
            if (castFromStore == null){
                return NotFound();
            }
            movie.Casts.Remove(castFromStore);
            return NoContent();
        }
    }
}