using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeData.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FooterContent",
                table: "FooterAlts",
                newName: "FooterAltContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FooterAltContent",
                table: "FooterAlts",
                newName: "FooterContent");
        }
    }
}
