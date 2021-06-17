using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapiejemplo.Models;

namespace webapiejemplo.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get; set;}
        [Required (ErrorMessage ="El nombre es requerido")]
        [MaxLength(30)]
        public string Name{get; set;}
        [Required (ErrorMessage ="El nombre es requerido")]
        [MaxLength(400)]
        public string Description{get; set;}
        public ICollection<CastDto> Casts {get; set;}
    }
}