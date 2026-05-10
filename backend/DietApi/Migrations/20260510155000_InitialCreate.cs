using System;
using DietApi.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietApi.Migrations
{
    [DbContext(typeof(DietDbContext))]
    [Migration("20260510155000_InitialCreate")]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Message = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    ActivityLevel = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    ActivityCoefficient = table.Column<double>(type: "REAL", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    Proteins = table.Column<int>(type: "INTEGER", nullable: false),
                    Fats = table.Column<int>(type: "INTEGER", nullable: false),
                    Carbohydrates = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuPlan = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietCalculations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietCalculations_CreatedAt",
                table: "DietCalculations",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_DietCalculations_UserId",
                table: "DietCalculations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackMessages_CreatedAt",
                table: "FeedbackMessages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "DietCalculations");
            migrationBuilder.DropTable(name: "FeedbackMessages");
            migrationBuilder.DropTable(name: "Users");
        }
    }
}
