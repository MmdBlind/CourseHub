using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseHub.Migrations
{
    /// <inheritdoc />
    public partial class EditMigrationCreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Categories_Categories_CategoryID1",
                table: "Course_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Categories_Courses_CourseID1",
                table: "Course_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teachers_Courses_CourseID1",
                table: "Course_Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teachers_Teachers_TeacherID1",
                table: "Course_Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Course_Teachers_CourseID1",
                table: "Course_Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Course_Teachers_TeacherID1",
                table: "Course_Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Course_Categories_CategoryID1",
                table: "Course_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Course_Categories_CourseID1",
                table: "Course_Categories");

            migrationBuilder.DropColumn(
                name: "CourseID1",
                table: "Course_Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherID1",
                table: "Course_Teachers");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Course_Categories");

            migrationBuilder.DropColumn(
                name: "CourseID1",
                table: "Course_Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID1",
                table: "Course_Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID1",
                table: "Course_Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Course_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseID1",
                table: "Course_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teachers_CourseID1",
                table: "Course_Teachers",
                column: "CourseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Teachers_TeacherID1",
                table: "Course_Teachers",
                column: "TeacherID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Categories_CategoryID1",
                table: "Course_Categories",
                column: "CategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Categories_CourseID1",
                table: "Course_Categories",
                column: "CourseID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Categories_Categories_CategoryID1",
                table: "Course_Categories",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Categories_Courses_CourseID1",
                table: "Course_Categories",
                column: "CourseID1",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teachers_Courses_CourseID1",
                table: "Course_Teachers",
                column: "CourseID1",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teachers_Teachers_TeacherID1",
                table: "Course_Teachers",
                column: "TeacherID1",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
