using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LMS.Data.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attempts",
                columns: table => new
                {
                    attemptId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    noAttempts = table.Column<int>(nullable: false),
                    score = table.Column<int>(nullable: false),
                    time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attempts", x => x.attemptId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    useremail = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    courseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    categoriescategory_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_courses_categories_categoriescategory_id",
                        column: x => x.categoriescategory_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    unitId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    timeSpent = table.Column<int>(nullable: false),
                    compStatus = table.Column<string>(nullable: true),
                    score = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    courseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.unitId);
                    table.ForeignKey(
                        name: "FK_units_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    questionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    question = table.Column<string>(nullable: true),
                    type = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    unitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.questionId);
                    table.ForeignKey(
                        name: "FK_questions_units_unitId",
                        column: x => x.unitId,
                        principalTable: "units",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "choices",
                columns: table => new
                {
                    choiceId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    choice = table.Column<string>(nullable: true),
                    isCorrect = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    questionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choices", x => x.choiceId);
                    table.ForeignKey(
                        name: "FK_choices_questions_questionId",
                        column: x => x.questionId,
                        principalTable: "questions",
                        principalColumn: "questionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    responseId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userId = table.Column<Guid>(nullable: true),
                    questionId = table.Column<int>(nullable: true),
                    choiceId = table.Column<int>(nullable: true),
                    isCorrect = table.Column<bool>(nullable: false),
                    response = table.Column<string>(nullable: true),
                    attemptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.responseId);
                    table.ForeignKey(
                        name: "FK_responses_attempts_attemptId",
                        column: x => x.attemptId,
                        principalTable: "attempts",
                        principalColumn: "attemptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_responses_choices_choiceId",
                        column: x => x.choiceId,
                        principalTable: "choices",
                        principalColumn: "choiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_responses_questions_questionId",
                        column: x => x.questionId,
                        principalTable: "questions",
                        principalColumn: "questionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_responses_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_choices_questionId",
                table: "choices",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_categoriescategory_id",
                table: "courses",
                column: "categoriescategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_unitId",
                table: "questions",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_attemptId",
                table: "responses",
                column: "attemptId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_choiceId",
                table: "responses",
                column: "choiceId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_questionId",
                table: "responses",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_responses_userId",
                table: "responses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_units_courseId",
                table: "units",
                column: "courseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "attempts");

            migrationBuilder.DropTable(
                name: "choices");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
