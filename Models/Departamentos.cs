using System.ComponentModel.DataAnnotations;

namespace NominaApp.Models
{
    public class Departamentos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Departamento Requerido")]
        public required string Nombre { get; set; }
    }
}
