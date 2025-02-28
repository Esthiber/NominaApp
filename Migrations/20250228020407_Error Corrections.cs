using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaApp.Migrations
{
    /// <inheritdoc />
    public partial class ErrorCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PagosNomina",
                keyColumn: "PagoNominaId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PagosNomina",
                keyColumn: "PagoNominaId",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PagosNomina",
                keyColumn: "PagoNominaId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 2, 27, 21, 59, 7, 230, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "PagosNomina",
                keyColumn: "PagoNominaId",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 2, 27, 21, 59, 7, 231, DateTimeKind.Local).AddTicks(678));
        }
    }
}
