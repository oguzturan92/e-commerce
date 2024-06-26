using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeData.Migrations
{
    public partial class start3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterAltSeoDescription",
                table: "FooterAlts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FooterAltSeoKeyword",
                table: "FooterAlts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FooterAltSeoTitle",
                table: "FooterAlts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterAltSeoDescription",
                table: "FooterAlts");

            migrationBuilder.DropColumn(
                name: "FooterAltSeoKeyword",
                table: "FooterAlts");

            migrationBuilder.DropColumn(
                name: "FooterAltSeoTitle",
                table: "FooterAlts");
        }
    }
}
