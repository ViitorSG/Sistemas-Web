using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscaCep.Migrations
{
    /// <inheritdoc />
    public partial class AddFotoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoFoto",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoFoto",
                table: "Pessoas");
        }
    }
}
