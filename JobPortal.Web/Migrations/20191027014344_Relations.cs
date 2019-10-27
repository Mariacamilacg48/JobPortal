using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Web.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicProgramId",
                table: "UserITMs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "UserITMs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NIT = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    VacanciesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprises_Vacancies_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacancyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VacanciesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyTypes_Vacancies_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VancancyPostulations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    userITMId = table.Column<int>(nullable: true),
                    EnterpriseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VancancyPostulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VancancyPostulations_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VancancyPostulations_UserITMs_userITMId",
                        column: x => x.userITMId,
                        principalTable: "UserITMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterviewMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    VancancyPostulationsId = table.Column<int>(nullable: true),
                    AgendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewMeetings_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterviewMeetings_VancancyPostulations_VancancyPostulationsId",
                        column: x => x.VancancyPostulationsId,
                        principalTable: "VancancyPostulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostulationStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VancancyPostulationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostulationStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostulationStates_VancancyPostulations_VancancyPostulationsId",
                        column: x => x.VancancyPostulationsId,
                        principalTable: "VancancyPostulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    InterviewMeetingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingStates_InterviewMeetings_InterviewMeetingId",
                        column: x => x.InterviewMeetingId,
                        principalTable: "InterviewMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserITMs_AcademicProgramId",
                table: "UserITMs",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_UserITMs_UserTypeId",
                table: "UserITMs",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_VacanciesId",
                table: "Enterprises",
                column: "VacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewMeetings_AgendaId",
                table: "InterviewMeetings",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewMeetings_VancancyPostulationsId",
                table: "InterviewMeetings",
                column: "VancancyPostulationsId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingStates_InterviewMeetingId",
                table: "MeetingStates",
                column: "InterviewMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_PostulationStates_VancancyPostulationsId",
                table: "PostulationStates",
                column: "VancancyPostulationsId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyTypes_VacanciesId",
                table: "VacancyTypes",
                column: "VacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_VancancyPostulations_EnterpriseId",
                table: "VancancyPostulations",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_VancancyPostulations_userITMId",
                table: "VancancyPostulations",
                column: "userITMId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserITMs_AcademicPrograms_AcademicProgramId",
                table: "UserITMs",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserITMs_UserType_UserTypeId",
                table: "UserITMs",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserITMs_AcademicPrograms_AcademicProgramId",
                table: "UserITMs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserITMs_UserType_UserTypeId",
                table: "UserITMs");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "MeetingStates");

            migrationBuilder.DropTable(
                name: "PostulationStates");

            migrationBuilder.DropTable(
                name: "VacancyTypes");

            migrationBuilder.DropTable(
                name: "InterviewMeetings");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "VancancyPostulations");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_UserITMs_AcademicProgramId",
                table: "UserITMs");

            migrationBuilder.DropIndex(
                name: "IX_UserITMs_UserTypeId",
                table: "UserITMs");

            migrationBuilder.DropColumn(
                name: "AcademicProgramId",
                table: "UserITMs");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "UserITMs");
        }
    }
}
