using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LMS.Data.Migrations
{
    public partial class addinitalentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enrolls",
                columns: table => new
                {
                    enrollId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    enrollstatus = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<Guid>(nullable: true),
                    courseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrolls", x => x.enrollId);
                    table.ForeignKey(
                        name: "FK_enrolls_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_enrolls_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrolls_courseId",
                table: "enrolls",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_enrolls_userId",
                table: "enrolls",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrolls");
        }
    }
}
