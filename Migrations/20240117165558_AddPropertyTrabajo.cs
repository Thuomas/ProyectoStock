using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stock.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyTrabajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrdenTrabajo",
                table: "Trabajo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdenTrabajo",
                table: "Trabajo");
        }
    }
}
