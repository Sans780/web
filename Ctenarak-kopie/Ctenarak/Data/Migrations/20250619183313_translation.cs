using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ctenarak.Data.Migrations
{
    public partial class translation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Article",
                newName: "Titulek");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Article",
                newName: "Popis");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Article",
                newName: "Obsah");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulek",
                table: "Article",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Popis",
                table: "Article",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Obsah",
                table: "Article",
                newName: "Content");
        }
    }
}
