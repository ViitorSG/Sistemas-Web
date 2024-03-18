using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    /// <inheritdoc />
    public partial class updateRentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_CarId",
                table: "Rents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_ClientId",
                table: "Rents",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fk_CarId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "fk_ClientId",
                table: "Rents");
        }
    }
}
