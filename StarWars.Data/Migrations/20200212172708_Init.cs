using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Episodes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFriendships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstId = table.Column<Guid>(nullable: true),
                    SecondId = table.Column<Guid>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFriendships_Characters_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterFriendships_Characters_SecondId",
                        column: x => x.SecondId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriendships_FirstId",
                table: "CharacterFriendships",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriendships_SecondId",
                table: "CharacterFriendships",
                column: "SecondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFriendships");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
