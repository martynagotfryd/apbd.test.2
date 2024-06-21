using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "backpack",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backpack", x => new { x.IdCharacter, x.IdItem });
                    table.ForeignKey(
                        name: "FK_backpack_character_IdCharacter",
                        column: x => x.IdCharacter,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_backpack_item_IdItem",
                        column: x => x.IdItem,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "charactertitle",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "int", nullable: false),
                    IdTitle = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charactertitle", x => new { x.IdCharacter, x.IdTitle });
                    table.ForeignKey(
                        name: "FK_charactertitle_character_IdCharacter",
                        column: x => x.IdCharacter,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_charactertitle_title_IdTitle",
                        column: x => x.IdTitle,
                        principalTable: "title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "character",
                columns: new[] { "Id", "CurrWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 5, "To", "Ja", 20 });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[] { 1, "lol", 3 });

            migrationBuilder.InsertData(
                table: "title",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "elo" });

            migrationBuilder.InsertData(
                table: "backpack",
                columns: new[] { "IdCharacter", "IdItem", "Amount" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "charactertitle",
                columns: new[] { "IdCharacter", "IdTitle", "AcquiredAt" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 21, 16, 10, 47, 308, DateTimeKind.Local).AddTicks(7535) });

            migrationBuilder.CreateIndex(
                name: "IX_backpack_IdItem",
                table: "backpack",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_charactertitle_IdTitle",
                table: "charactertitle",
                column: "IdTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backpack");

            migrationBuilder.DropTable(
                name: "charactertitle");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "title");
        }
    }
}
