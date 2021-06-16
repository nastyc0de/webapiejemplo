using System.ComponentModel.DataAnnotations;

namespace apiWeb.Models
{
    public class UpdateCastDto
    {
        [Required (ErrorMessage ="El nombre es requerido")]
        [MaxLength(30)]
        public string Name {get; set;}
        
        [MaxLength(30)]
        public string CharName {get; set;}
    }
}