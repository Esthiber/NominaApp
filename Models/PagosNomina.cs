using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaApp.Models
{
    public class PagosNomina
    {
        [Key]
        public int PagoNominaId { get; set; }

        [Required(ErrorMessage = "Requerido Empleado")]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Requerido Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Requerido Sueldo Bruto")]
        public double SueldoBruto { get; set; }

        [Required(ErrorMessage = "Requerido Descuentos")]
        public double Descuentos { get; set; }

        [Required(ErrorMessage = "Requerido Sueldo Neto")]
        public double SueldoNeto { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleados Empleado { get; set; } = null;
    }
}
