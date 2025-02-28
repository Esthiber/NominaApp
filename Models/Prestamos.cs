using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaApp.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Requerido Empleado")]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Requerido Monto")]
        [Range(1, 500000, ErrorMessage = "Monto debe ser mayor a 1 y menor que 500,000.")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Requerido Cuotas")]
        public int Cuotas { get; set; }

        public bool Pagado { get; set; } = false;

        [ForeignKey("EmpleadoId")]
        [InverseProperty("Prestamos")]
        public Empleados Empleado { get; set; } = null;
    }
}
