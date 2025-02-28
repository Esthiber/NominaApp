using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaApp.Models
{
    public class Departamentos
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Nombre Departamento Requerido")]
        public required string Nombre { get; set; }

        [InverseProperty("Departamento")]
        public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
    }
}
