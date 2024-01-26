using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.Migrations
{
    /// <inheritdoc />
    public partial class AddEntregasSmt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntregasSmt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Remito = table.Column<string>(type: "TEXT", nullable: false),
                    OrdenTrabajoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadRestante = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregasSmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntregasSmt_Trabajo_OrdenTrabajoId",
                        column: x => x.OrdenTrabajoId,
                        principalTable: "Trabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregasSmt_OrdenTrabajoId",
                table: "EntregasSmt",
                column: "OrdenTrabajoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregasSmt");
        }
    }
}
