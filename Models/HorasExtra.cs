using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaApp.Models
{
    public class HorasExtra
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Requerido Empleado")]
        public int EmpleadoId { get; set; }
        
        [Required(ErrorMessage = "Requerido Cantidad Horas")]
        [Range(1,80,ErrorMessage ="Cantidad de Horas debe ser mayor a 1 y menor que 80.")]
        public int CantidadHoras { get; set; }

        public bool Pagada { get; set; }

        public bool Nocturnas { get; set; } = false;

        [ForeignKey("EmpleadoId")]
        [InverseProperty("HorasExtras")]
        public Empleados empleado { get; set; } = null;
    }
}
