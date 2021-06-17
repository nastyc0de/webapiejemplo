using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiejemplo.Entities
{
    public class Cast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [Required (ErrorMessage ="El nombre es requerido")]
        [MaxLength(30)]
        public string Name {get; set;}
        [Required (ErrorMessage ="El char nombre es requerido")]
        [MaxLength(30)]
        public string CharName {get; set;}

        [ForeignKey("MovieId")]
        public Movie Movie {get; set;}
        public int MovieId {get; set;}
    }
}