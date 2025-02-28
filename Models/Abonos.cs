using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaApp.Models
{
    public class Abonos
    {
        [Key]
        public int AbonoId { get; set; }
        [Required(ErrorMessage ="Debe Seleccionar el prestamo.")]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="Es requerido el monto.")]
        [Range(1, 500000, ErrorMessage = "Monto debe ser mayor a 1 y menor que 500,000.")]
        public double Monto { get; set; }

        [ForeignKey("PrestamoId")]
        [InverseProperty("Abonos")]
        public Prestamos Prestamo { get; set; } = null;
    }
}
