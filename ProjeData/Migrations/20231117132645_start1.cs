using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeData.Migrations
{
    public partial class start1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterContent",
                table: "FooterAlts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 1,
                column: "FooterAltLink",
                value: "iletisim");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 2,
                column: "FooterAltLink",
                value: "kariyer");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 3,
                column: "FooterAltLink",
                value: "hakkimizda");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 4,
                column: "FooterAltLink",
                value: "iade-ve-degisim");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 5,
                column: "FooterAltLink",
                value: "sss");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 6,
                column: "FooterAltLink",
                value: "garanti");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 7,
                column: "FooterAltLink",
                value: "uyelik");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 8,
                column: "FooterAltLink",
                value: "siparis-takibi");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 9,
                column: "FooterAltLink",
                value: "kargo-ve-teslimat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterContent",
                table: "FooterAlts");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 1,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=iletisim");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 2,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=kariyer");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 3,
                column: "FooterAltLink",
                value: "/Category/CategoryListClient?url=hakkimizda");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 4,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=iade-ve-degisim");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 5,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=sss");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 6,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=garanti");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 7,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=uyelik");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 8,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=siparis-takibi");

            migrationBuilder.UpdateData(
                table: "FooterAlts",
                keyColumn: "FooterAltId",
                keyValue: 9,
                column: "FooterAltLink",
                value: "/Category2/Category2ListClient?url=kargo-ve-teslimat");
        }
    }
}
