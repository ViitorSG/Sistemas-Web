using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    /// <inheritdoc />
    public partial class updateRentModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Cars_fk_CarId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Clients_fk_ClientId",
                table: "Rents");

            migrationBuilder.AlterColumn<int>(
                name: "fk_ClientId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fk_CarId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Cars_fk_CarId",
                table: "Rents",
                column: "fk_CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Clients_fk_ClientId",
                table: "Rents",
                column: "fk_ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Cars_fk_CarId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Clients_fk_ClientId",
                table: "Rents");

            migrationBuilder.AlterColumn<int>(
                name: "fk_ClientId",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fk_CarId",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Cars_fk_CarId",
                table: "Rents",
                column: "fk_CarId",
                principalTable: "Cars",
                principalColumn: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Clients_fk_ClientId",
                table: "Rents",
                column: "fk_ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }
    }
}
