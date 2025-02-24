using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.Migrations
{
    /// <inheritdoc />
    public partial class ObservacionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Observacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirmwareVersion = table.Column<int>(type: "INTEGER", nullable: false),
                    Grabador = table.Column<string>(type: "TEXT", nullable: false),
                    NumSerieGrabador = table.Column<string>(type: "TEXT", nullable: false),
                    Amp = table.Column<double>(type: "REAL", nullable: false),
                    Bpm = table.Column<int>(type: "INTEGER", nullable: false),
                    Simulador = table.Column<string>(type: "TEXT", nullable: false),
                    NumSerieSimulador = table.Column<int>(type: "INTEGER", nullable: false),
                    SoftAnalisis = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observacion");
        }
    }
}
