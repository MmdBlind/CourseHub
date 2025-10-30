using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorySlug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryParentID",
                        column: x => x.CategoryParentID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CourseSlug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false),
                    CoursePublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    CourseImagePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CourseIsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherFullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    TeacherBio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Course_Categories",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CourseID1 = table.Column<int>(type: "int", nullable: false),
                    CategoryID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Categories", x => new { x.CourseID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_Course_Categories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Categories_Categories_CategoryID1",
                        column: x => x.CategoryID1,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Categories_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Categories_Courses_CourseID1",
                        column: x => x.CourseID1,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_Teachers",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    CourseID1 = table.Column<int>(type: "int", nullable: false),
                    TeacherID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Teachers", x => new { x.CourseID, x.TeacherID });
                    table.ForeignKey(
                        name: "FK_Course_Teachers_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Teachers_Courses_CourseID1",
                        column: x => x.CourseID1,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Teachers_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Teachers_Teachers_TeacherID1",
                        column: x => x.TeacherID1,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryParentID",
                table: "Categories",
                column: "CategoryParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_CategorySlug",
                table: "Categories",
                column: "CategorySlug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Categories_CategoryID",
                table: "Course_Categories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Categories_CategoryID1",
                table: "Course_Categories",
                column: "CategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Categories_CourseID1",
                table: "Course_Categories",
                column: "CourseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teachers_CourseID1",
                table: "Course_Teachers",
                column: "CourseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teachers_TeacherID",
                table: "Course_Teachers",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teachers_TeacherID1",
                table: "Course_Teachers",
                column: "TeacherID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseSlug",
                table: "Courses",
                column: "CourseSlug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Categories");

            migrationBuilder.DropTable(
                name: "Course_Teachers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
