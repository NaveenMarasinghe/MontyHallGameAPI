using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MontyHall.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SwitchDoorNumber",
                table: "GameData");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedDoorNumber",
                table: "GameData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<bool>(
                name: "SwitchDoor",
                table: "GameData",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SwitchDoor",
                table: "GameData");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedDoorNumber",
                table: "GameData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "SwitchDoorNumber",
                table: "GameData",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);
        }
    }
}
