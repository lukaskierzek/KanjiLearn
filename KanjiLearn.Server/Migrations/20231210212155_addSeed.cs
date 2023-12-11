using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanjiLearn.Server.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kanji",
                columns: new[] { "Id", "Character", "Created", "LastModified", "Strokes", "Translation" },
                values: new object[] { 1, "人", new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7468), new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7471), 999, "Człowiek" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Created", "KanjiId", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[] { 1, new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7691), 1, "", new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7692), "" });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "KanjiId", "LastModified", "Sentence", "Translation" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7716), 1, new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7717), "ss1", "tttt1" },
                    { 2, new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7719), 1, new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7721), "ss2", "tttt2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_KanjiId",
                table: "Readings",
                column: "KanjiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings",
                column: "KanjiId",
                principalTable: "Kanji",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_KanjiId",
                table: "Readings");

            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
