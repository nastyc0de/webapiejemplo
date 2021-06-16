using System.ComponentModel.DataAnnotations;

namespace apiWeb.Models
{
    public class NewCastDto
    {
        public int Id {get; set;}
        [Required (ErrorMessage ="El nombre es requerido")]
        [MaxLength(30)]
        public string Name {get; set;}
        [Required (ErrorMessage ="El char nombre es requerido")]
        [MaxLength(30)]
        public string CharName {get; set;}
    }
}