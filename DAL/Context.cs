using Microsoft.EntityFrameworkCore;
using NominaApp.Models;

namespace NominaApp.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Empleados> Empleados { get; set; }

        public DbSet<Departamentos> Departamentos { get; set; }

        public DbSet<HorasExtra> HorasExtras { get; set; }

        public DbSet<Prestamos> Prestamos { get; set; }

        public DbSet<Abonos> Abonos { get; set; }

        public DbSet<PagosNomina> PagosNomina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla Empleados
            modelBuilder.Entity<Empleados>()
                .HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada

            // Configuración de la tabla HorasExtras
            modelBuilder.Entity<HorasExtra>()
                .HasOne(h => h.Empleado)
                .WithMany(e => e.HorasExtras)
                .HasForeignKey(h => h.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la tabla Prestamos
            modelBuilder.Entity<Prestamos>()
                .HasOne(p => p.Empleado)
                .WithMany(e => e.Prestamos)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la tabla Abonos
            modelBuilder.Entity<Abonos>()
                .HasOne(a => a.Prestamo)
                .WithMany(p => p.Abonos)
                .HasForeignKey(a => a.PrestamoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la tabla PagoNomina
            modelBuilder.Entity<PagosNomina>()
                .HasOne(p => p.Empleado)
                .WithMany(e => e.PagosNomina)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Insertar Departamentos
            modelBuilder.Entity<Departamentos>().HasData(
                new Departamentos { DepartamentoId = 1, Nombre = "Recursos Humanos" },
                new Departamentos { DepartamentoId = 2, Nombre = "Tecnología" },
                new Departamentos { DepartamentoId = 3, Nombre = "Contabilidad" },
                new Departamentos { DepartamentoId = 4, Nombre = "Ventas" }
            );

            // Insertar Empleados
            modelBuilder.Entity<Empleados>().HasData(
                new Empleados { EmpleadoId = 1, Nombre = "Juan", Apellido = "Perez", Cedula = "00123456789", Telefono = "8095551234", Profesion = "Analista", DepartamentoId = 2, Puesto = "Desarrollador", Sueldo = 50000 },
                new Empleados { EmpleadoId = 2, Nombre = "Maria", Apellido = "Gomez", Cedula = "00234567891", Telefono = "8095555678", Profesion = "Contadora", DepartamentoId = 3, Puesto = "Contadora Senior", Sueldo = 60000 },
                new Empleados { EmpleadoId = 3, Nombre = "Carlos", Apellido = "Lopez", Cedula = "00345678912", Telefono = "8095558765", Profesion = "Vendedor", DepartamentoId = 4, Puesto = "Ejecutivo de Ventas", Sueldo = 45000 },
                new Empleados { EmpleadoId = 4, Nombre = "Ana", Apellido = "Fernandez", Cedula = "00456789123", Telefono = "8095552345", Profesion = "Recursos Humanos", DepartamentoId = 1, Puesto = "Coordinadora", Sueldo = 55000 },
                new Empleados { EmpleadoId = 5, Nombre = "Pedro", Apellido = "Martinez", Cedula = "00567891234", Telefono = "8095559876", Profesion = "Analista", DepartamentoId = 2, Puesto = "QA", Sueldo = 52000 },
                // Agrega 15 empleados más con datos variados
                new Empleados { EmpleadoId = 6, Nombre = "Laura", Apellido = "Jimenez", Cedula = "00678912345", Telefono = "8095553456", Profesion = "Vendedor", DepartamentoId = 4, Puesto = "Vendedor", Sueldo = 42000 },
                new Empleados { EmpleadoId = 7, Nombre = "Diego", Apellido = "Torres", Cedula = "00789123456", Telefono = "8095556543", Profesion = "Contador", DepartamentoId = 3, Puesto = "Asistente Contable", Sueldo = 38000 },
                new Empleados { EmpleadoId = 8, Nombre = "Sofia", Apellido = "Castro", Cedula = "00891234567", Telefono = "8095557654", Profesion = "Recursos Humanos", DepartamentoId = 1, Puesto = "Especialista", Sueldo = 50000 },
                new Empleados { EmpleadoId = 9, Nombre = "Fernando", Apellido = "Guzman", Cedula = "00912345678", Telefono = "8095558765", Profesion = "Desarrollador", DepartamentoId = 2, Puesto = "Backend Developer", Sueldo = 70000 },
                new Empleados { EmpleadoId = 10, Nombre = "Valentina", Apellido = "Ortiz", Cedula = "01023456789", Telefono = "8095559876", Profesion = "Vendedor", DepartamentoId = 4, Puesto = "Vendedor", Sueldo = 40000 }
            );

            // Insertar Horas Extras
            modelBuilder.Entity<HorasExtra>().HasData(
                new HorasExtra { HorasExtraId = 1, EmpleadoId = 1, CantidadHoras = 10, Pagada = false },
                new HorasExtra { HorasExtraId = 2, EmpleadoId = 3, CantidadHoras = 8, Pagada = true }
            );

            // Insertar Prestamos
            modelBuilder.Entity<Prestamos>().HasData(
                new Prestamos { PrestamoId = 1, EmpleadoId = 2, Monto = 100000, Cuotas = 24, Pagado = false },
                new Prestamos { PrestamoId = 2, EmpleadoId = 4, Monto = 50000, Cuotas = 12, Pagado = false }
            );

            // Insertar Abonos
            modelBuilder.Entity<Abonos>().HasData(
                new Abonos { AbonoId = 1, PrestamoId = 1, Monto = 5000 },
                new Abonos { AbonoId = 2, PrestamoId = 2, Monto = 4200 }
            );

            // Insertar Pagos de Nómina
            modelBuilder.Entity<PagosNomina>().HasData(
                new PagosNomina { PagoNominaId = 1, EmpleadoId = 1, Fecha = new DateTime(2025, 2, 27), SueldoBruto = 50000, Descuentos = 8000, SueldoNeto = 42000 },
                new PagosNomina { PagoNominaId = 2, EmpleadoId = 2, Fecha = new DateTime(2025, 2, 27), SueldoBruto = 60000, Descuentos = 10000, SueldoNeto = 50000 }
            );




            base.OnModelCreating(modelBuilder);
        }
    }
}
