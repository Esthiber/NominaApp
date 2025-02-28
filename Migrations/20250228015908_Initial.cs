using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NominaApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorasExtras",
                columns: table => new
                {
                    HorasExtraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    CantidadHoras = table.Column<int>(type: "int", nullable: false),
                    Pagada = table.Column<bool>(type: "bit", nullable: false),
                    Nocturnas = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasExtras", x => x.HorasExtraId);
                    table.ForeignKey(
                        name: "FK_HorasExtras_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosNomina",
                columns: table => new
                {
                    PagoNominaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SueldoBruto = table.Column<double>(type: "float", nullable: false),
                    Descuentos = table.Column<double>(type: "float", nullable: false),
                    SueldoNeto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosNomina", x => x.PagoNominaId);
                    table.ForeignKey(
                        name: "FK_PagosNomina_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonos",
                columns: table => new
                {
                    AbonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonos", x => x.AbonoId);
                    table.ForeignKey(
                        name: "FK_Abonos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Recursos Humanos" },
                    { 2, "Tecnología" },
                    { 3, "Contabilidad" },
                    { 4, "Ventas" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Cedula", "DepartamentoId", "Nombre", "Profesion", "Puesto", "Sueldo", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", "00123456789", 2, "Juan", "Analista", "Desarrollador", 50000.0, "8095551234" },
                    { 2, "Gomez", "00234567891", 3, "Maria", "Contadora", "Contadora Senior", 60000.0, "8095555678" },
                    { 3, "Lopez", "00345678912", 4, "Carlos", "Vendedor", "Ejecutivo de Ventas", 45000.0, "8095558765" },
                    { 4, "Fernandez", "00456789123", 1, "Ana", "Recursos Humanos", "Coordinadora", 55000.0, "8095552345" },
                    { 5, "Martinez", "00567891234", 2, "Pedro", "Analista", "QA", 52000.0, "8095559876" },
                    { 6, "Jimenez", "00678912345", 4, "Laura", "Vendedor", "Vendedor", 42000.0, "8095553456" },
                    { 7, "Torres", "00789123456", 3, "Diego", "Contador", "Asistente Contable", 38000.0, "8095556543" },
                    { 8, "Castro", "00891234567", 1, "Sofia", "Recursos Humanos", "Especialista", 50000.0, "8095557654" },
                    { 9, "Guzman", "00912345678", 2, "Fernando", "Desarrollador", "Backend Developer", 70000.0, "8095558765" },
                    { 10, "Ortiz", "01023456789", 4, "Valentina", "Vendedor", "Vendedor", 40000.0, "8095559876" }
                });

            migrationBuilder.InsertData(
                table: "HorasExtras",
                columns: new[] { "HorasExtraId", "CantidadHoras", "EmpleadoId", "Nocturnas", "Pagada" },
                values: new object[,]
                {
                    { 1, 10, 1, false, false },
                    { 2, 8, 3, false, true }
                });

            migrationBuilder.InsertData(
                table: "PagosNomina",
                columns: new[] { "PagoNominaId", "Descuentos", "EmpleadoId", "Fecha", "SueldoBruto", "SueldoNeto" },
                values: new object[,]
                {
                    { 1, 8000.0, 1, new DateTime(2025, 2, 27, 21, 59, 7, 230, DateTimeKind.Local).AddTicks(9431), 50000.0, 42000.0 },
                    { 2, 10000.0, 2, new DateTime(2025, 2, 27, 21, 59, 7, 231, DateTimeKind.Local).AddTicks(678), 60000.0, 50000.0 }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "PrestamoId", "Cuotas", "EmpleadoId", "Monto", "Pagado" },
                values: new object[,]
                {
                    { 1, 24, 2, 100000.0, false },
                    { 2, 12, 4, 50000.0, false }
                });

            migrationBuilder.InsertData(
                table: "Abonos",
                columns: new[] { "AbonoId", "Monto", "PrestamoId" },
                values: new object[,]
                {
                    { 1, 5000.0, 1 },
                    { 2, 4200.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonos_PrestamoId",
                table: "Abonos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasExtras_EmpleadoId",
                table: "HorasExtras",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosNomina_EmpleadoId",
                table: "PagosNomina",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EmpleadoId",
                table: "Prestamos",
                column: "EmpleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonos");

            migrationBuilder.DropTable(
                name: "HorasExtras");

            migrationBuilder.DropTable(
                name: "PagosNomina");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
