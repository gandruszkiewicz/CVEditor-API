using Microsoft.EntityFrameworkCore.Migrations;

namespace CVEditorAPI.Migrations
{
    public partial class AddDocumentNameToResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Resumes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Resumes");

        }
    }
}
