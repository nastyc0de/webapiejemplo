using System;
using Microsoft.AspNetCore.Mvc;
using webapiejemplo.Context;

namespace webapiejemplo.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController:ControllerBase
    {
        private MovieInfoContext _context;
        public DummyController(MovieInfoContext context){
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Testdatabase(){
            return Ok();
        }
    }
}