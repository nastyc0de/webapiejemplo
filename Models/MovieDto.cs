using System.Collections.Generic;
using webapiejemplo.Models;

namespace apiWeb.Models
{
    public class MovieDto
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public ICollection<CastDto> Casts {get; set;}
    }
}