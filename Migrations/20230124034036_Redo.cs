using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMLinkedInAttempt57.Migrations
{
    public partial class Redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerGuess = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuessTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKGuessId = table.Column<int>(type: "int", nullable: false),
                    TimeOfGuess = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuessTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuessTimes_Guesses_FKGuessId",
                        column: x => x.FKGuessId,
                        principalTable: "Guesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuessTimes_FKGuessId",
                table: "GuessTimes",
                column: "FKGuessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuessTimes");

            migrationBuilder.DropTable(
                name: "Guesses");
        }
    }
}
