using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVEditorAPI.Migrations
{
    public partial class AddedQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalExperience_Resumes_ResumeId",
                table: "ProfessionalExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalExperience",
                table: "ProfessionalExperience");

            migrationBuilder.RenameTable(
                name: "ProfessionalExperience",
                newName: "ProfessionalExperiences");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalExperience_ResumeId",
                table: "ProfessionalExperiences",
                newName: "IX_ProfessionalExperiences_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalExperiences",
                table: "ProfessionalExperiences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AcademicDegree = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ResumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifications_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_ResumeId",
                table: "Qualifications",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalExperiences_Resumes_ResumeId",
                table: "ProfessionalExperiences",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalExperiences_Resumes_ResumeId",
                table: "ProfessionalExperiences");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessionalExperiences",
                table: "ProfessionalExperiences");

            migrationBuilder.RenameTable(
                name: "ProfessionalExperiences",
                newName: "ProfessionalExperience");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalExperiences_ResumeId",
                table: "ProfessionalExperience",
                newName: "IX_ProfessionalExperience_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessionalExperience",
                table: "ProfessionalExperience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalExperience_Resumes_ResumeId",
                table: "ProfessionalExperience",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
