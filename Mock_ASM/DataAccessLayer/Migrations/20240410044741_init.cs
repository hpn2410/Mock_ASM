using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_code = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class__FDF4798613B0ABE7", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instructor_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__A1EF56E82CAFDCB3", x => x.instructor_id);
                });

            migrationBuilder.CreateTable(
                name: "Student_Info",
                columns: table => new
                {
                    student_info_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student___8E40FB55BA9B17B1", x => x.student_info_id);
                });

            migrationBuilder.CreateTable(
                name: "Class_Instructor",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false),
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class_In__67EA8CE811DF3DF7", x => new { x.class_id, x.instructor_id });
                    table.ForeignKey(
                        name: "FK__Class_Ins__class__34C8D9D1",
                        column: x => x.class_id,
                        principalTable: "Class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK__Class_Ins__instr__35BCFE0A",
                        column: x => x.instructor_id,
                        principalTable: "Instructor",
                        principalColumn: "instructor_id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_code = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    student_info_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__2A33069AECCB0CEF", x => x.student_id);
                    table.ForeignKey(
                        name: "FK__Student__class_i__2F10007B",
                        column: x => x.class_id,
                        principalTable: "Class",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK__Student__student__2E1BDC42",
                        column: x => x.student_info_id,
                        principalTable: "Student_Info",
                        principalColumn: "student_info_id");
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "class_id", "class_code" },
                values: new object[] { 1, "CS101" });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "instructor_id", "date_of_birth", "email", "instructor_name", "phone" },
                values: new object[] { 1, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "Jane Smith", "0987654321" });

            migrationBuilder.InsertData(
                table: "Student_Info",
                columns: new[] { "student_info_id", "date_of_birth", "email", "phone", "student_name" },
                values: new object[] { 1, new DateTime(2002, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyendz@example.com", "1234567890", "NguyenDZ" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "student_id", "class_id", "student_code", "student_info_id" },
                values: new object[] { 1, 1, "S001", 1 });

            migrationBuilder.CreateIndex(
                name: "UQ__Class__0AF9B2E4A3BA1D7A",
                table: "Class",
                column: "class_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_Instructor_instructor_id",
                table: "Class_Instructor",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Instruct__AB6E6164A2065F42",
                table: "Instructor",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_id",
                table: "Student",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_student_info_id",
                table: "Student",
                column: "student_info_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Student___AB6E61649A2245A9",
                table: "Student_Info",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class_Instructor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Student_Info");
        }
    }
}
