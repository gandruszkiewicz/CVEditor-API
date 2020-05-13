using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVEditorAPI.Migrations
{
    public partial class RenamedProfessionalExperienceToExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                "ProfessionalExperiences", "dbo", "Experiences", "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
               "Experiences", "dbo", "ProfessionalExperiences", "dbo");
        }
    }
}
