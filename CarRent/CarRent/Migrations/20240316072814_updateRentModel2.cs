using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    /// <inheritdoc />
    public partial class updateRentModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Cars_CarId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Clients_ClientId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_CarId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ClientId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_fk_CarId",
                table: "Rents",
                column: "fk_CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_fk_ClientId",
                table: "Rents",
                column: "fk_ClientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Cars_fk_CarId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Clients_fk_ClientId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_fk_CarId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_fk_ClientId",
                table: "Rents");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarId",
                table: "Rents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Cars_CarId",
                table: "Rents",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Clients_ClientId",
                table: "Rents",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
