using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MontyHall.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenDoorNumber",
                table: "GameData",
                newName: "RevealDoorNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevealDoorNumber",
                table: "GameData",
                newName: "OpenDoorNumber");
        }
    }
}
