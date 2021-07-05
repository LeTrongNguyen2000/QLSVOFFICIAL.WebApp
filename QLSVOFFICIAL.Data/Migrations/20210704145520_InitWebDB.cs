using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSVOFFICIAL.Data.Migrations
{
    public partial class InitWebDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FACULTY",
                columns: table => new
                {
                    IdFaculty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FACULTY__0D72F2BFC3A486F4", x => x.IdFaculty);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROLE__B43690548B1B0BEC", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    IdClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    IdFaculty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLASS__003FCC7D1CC198E8", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_CLASS_FACULTY",
                        column: x => x.IdFaculty,
                        principalTable: "FACULTY",
                        principalColumn: "IdFaculty",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdFaculty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SUBJECT__BD949FF5026CD2E9", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_SUBJECT_FACULTY",
                        column: x => x.IdFaculty,
                        principalTable: "FACULTY",
                        principalColumn: "IdFaculty",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdFaculty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USER__B7C92638436CC53C", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_USER_FACULTY",
                        column: x => x.IdFaculty,
                        principalTable: "FACULTY",
                        principalColumn: "IdFaculty",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.IdRole,
                        principalTable: "ROLE",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLASS_SUBJECT",
                columns: table => new
                {
                    IdClassSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassSubjectName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DateStrart = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLASS_SU__4118476E48A95437", x => x.IdClassSubject);
                    table.ForeignKey(
                        name: "FK_CLASS_SUBJECT_SUBJECT",
                        column: x => x.IdSubject,
                        principalTable: "SUBJECT",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__STUDENT__61B35104D6218243", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_STUDENT_CLASS",
                        column: x => x.IdClass,
                        principalTable: "CLASS",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_USER",
                        column: x => x.IdUser,
                        principalTable: "USER",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHECKIN",
                columns: table => new
                {
                    IdCheckin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClassSubject = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CheckRoom = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHECKIN__1AC7AE399E0E9924", x => x.IdCheckin);
                    table.ForeignKey(
                        name: "FK_CHECKIN_CLASS_SUBJECT",
                        column: x => x.IdClassSubject,
                        principalTable: "CLASS_SUBJECT",
                        principalColumn: "IdClassSubject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHECKIN_USER",
                        column: x => x.IdUser,
                        principalTable: "USER",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ABSENCE_FORM",
                columns: table => new
                {
                    IdAbsenceForm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClassSubject = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ABSENCE___A7FCF44F4DC47F40", x => x.IdAbsenceForm);
                    table.ForeignKey(
                        name: "FK_ABSENCE_FORM_CLASS_SUBJECT",
                        column: x => x.IdClassSubject,
                        principalTable: "CLASS_SUBJECT",
                        principalColumn: "IdClassSubject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ABSENCE_FORM_STUDENT",
                        column: x => x.IdStudent,
                        principalTable: "STUDENT",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_CLASS_SUBJECT",
                columns: table => new
                {
                    IdClassSubject = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__STUDENT___1703727E0184EA17", x => new { x.IdClassSubject, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_STUDENT_CLASS_SUBJECT_CLASS_SUBJECT",
                        column: x => x.IdClassSubject,
                        principalTable: "CLASS_SUBJECT",
                        principalColumn: "IdClassSubject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_CLASS_SUBJECT_STUDENT",
                        column: x => x.IdStudent,
                        principalTable: "STUDENT",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_CHECKIN",
                columns: table => new
                {
                    IdCheckin = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__STUDENT___4CDC9B29D5D84085", x => new { x.IdCheckin, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_STUDENT_CHEKIN_CHECKIN",
                        column: x => x.IdCheckin,
                        principalTable: "CHECKIN",
                        principalColumn: "IdCheckin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_CHEKIN_STUDENT",
                        column: x => x.IdStudent,
                        principalTable: "STUDENT",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_CHEKIN_USER",
                        column: x => x.IdUser,
                        principalTable: "USER",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ABSENCE_FORM_IdClassSubject",
                table: "ABSENCE_FORM",
                column: "IdClassSubject");

            migrationBuilder.CreateIndex(
                name: "IX_ABSENCE_FORM_IdStudent",
                table: "ABSENCE_FORM",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKIN_IdClassSubject",
                table: "CHECKIN",
                column: "IdClassSubject");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKIN_IdUser",
                table: "CHECKIN",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CLASS_IdFaculty",
                table: "CLASS",
                column: "IdFaculty");

            migrationBuilder.CreateIndex(
                name: "unique_ClassName",
                table: "CLASS",
                column: "ClassName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLASS_SUBJECT_IdSubject",
                table: "CLASS_SUBJECT",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "unique_FacultyCode",
                table: "FACULTY",
                column: "FacultyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_RoleName",
                table: "ROLE",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_IdClass",
                table: "STUDENT",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_IdUser",
                table: "STUDENT",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CHECKIN_IdStudent",
                table: "STUDENT_CHECKIN",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CHECKIN_IdUser",
                table: "STUDENT_CHECKIN",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CLASS_SUBJECT_IdStudent",
                table: "STUDENT_CLASS_SUBJECT",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_SUBJECT_IdFaculty",
                table: "SUBJECT",
                column: "IdFaculty");

            migrationBuilder.CreateIndex(
                name: "unique_SubjectName",
                table: "SUBJECT",
                column: "SubjectName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_IdFaculty",
                table: "USER",
                column: "IdFaculty");

            migrationBuilder.CreateIndex(
                name: "IX_USER_IdRole",
                table: "USER",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "unique_UserName",
                table: "USER",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABSENCE_FORM");

            migrationBuilder.DropTable(
                name: "STUDENT_CHECKIN");

            migrationBuilder.DropTable(
                name: "STUDENT_CLASS_SUBJECT");

            migrationBuilder.DropTable(
                name: "CHECKIN");

            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "CLASS_SUBJECT");

            migrationBuilder.DropTable(
                name: "CLASS");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "SUBJECT");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "FACULTY");
        }
    }
}
