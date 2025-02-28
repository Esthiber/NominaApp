using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NominaApp.Models
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es Requerido.")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "La Cedula es Requerida.")]
        [StringLength(11, ErrorMessage = "Cedula no puede ser mayor a 11 caracteres.")]
        public required string Cedula { get; set; }

        [Required(ErrorMessage = "El Telefono es Requerido.")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Telefono no puede ser menor a 10 o mayor a 11")]
        public required string Telefono { get; set; }

        [Required(ErrorMessage = "La Profesion es Requerida.")]
        public required string Profesion { get; set; }

        [Required(ErrorMessage = "El Departamento es Requerido.")]
        [Range(1, int.MaxValue)]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "El Puesto es Requerido.")]
        public required string Puesto { get; set; }

        [Required(ErrorMessage = "El Sueldo es Requerido.")]
        [Range(0.01, 500000.00, ErrorMessage = "El sueldo no puede ser mayor a `500,000.00`.")]
        public double Sueldo { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual Departamentos? Departamento { get; set; } = null;

        [InverseProperty("Empleado")]
        public virtual ICollection<HorasExtra> HorasExtras { get; set; } = new List<HorasExtra>();

        [InverseProperty("Empleado")]
        public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
        // Metodos

        /// <summary>
        /// Calcula el descuento del AFP (2.87% del sueldo)
        /// </summary>
        public double getAFP()
        {
            return Sueldo * 0.0287; // 2.87%
        }

        /// <summary>
        /// Calcula el descuento del ARS (3.04% del sueldo)
        /// </summary>
        public double getARS()
        {
            return Sueldo * 0.0304; // 3.04%
        }

        /// <summary>
        /// Calcula el ISR según la escala de impuestos en República Dominicana.
        /// </summary>
        public double getISR()
        {
            double sueldoAnual = Sueldo * 12;

            if (sueldoAnual <= 416220.00)
                return 0; // Exento

            if (sueldoAnual <= 624329.00)
                return ((sueldoAnual - 416220.00) * 0.15) / 12; // 15% sobre el excedente

            if (sueldoAnual <= 867123.00)
                return ((sueldoAnual - 624329.00) * 0.20 + 31216.00) / 12; // 20% sobre el excedente + 31,216.00

            return ((sueldoAnual - 867123.00) * 0.25 + 79776.00) / 12; // 25% sobre el excedente + 79,776.00
        }

        /// <summary>
        /// Devuelve el número de horas extras trabajadas (Placeholder)
        /// </summary>
        public int getHorasExtra()
        {
            return 10; // Aquí puedes cambiarlo según el registro de horas extras
        }

        /// <summary>
        /// Calcula el sueldo por hora, asumiendo 160 horas de trabajo al mes (40 horas/semana)
        /// </summary>
        public double getSueldoHora()
        {
            return Sueldo / 160; // 160 horas al mes (40h semanales)
        }

        /// <summary>
        /// Calcula el pago por horas extras (1.5x del sueldo por hora)
        /// </summary>
        public double getPagoHorasExtra()
        {
            return getHorasExtra() * getSueldoHora() * 1.5;
        }

        /// <summary>
        /// Calcula el sueldo neto después de impuestos y deducciones
        /// </summary>
        public double getSueldoNeto()
        {
            double descuentos = getAFP() + getARS() + getISR();
            return Sueldo - descuentos + getPagoHorasExtra();
        }
    }
}
