using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MontyHall.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenDoorNumber",
                table: "GameData",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenDoorNumber",
                table: "GameData");
        }
    }
}
