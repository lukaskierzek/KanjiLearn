using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanjiLearn.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kanji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Character = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Strokes = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kunyomi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Onyomi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KanjiId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Kanji_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReadingKanjiInSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TranslationReadingKanjiInSentence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SentenceKanji = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KanjiId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentences_Kanji_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Kanji",
                columns: new[] { "Id", "Character", "Created", "LastModified", "Strokes", "Translation" },
                values: new object[,]
                {
                    { 1, "人", new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7508), new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7510), 2, "Człowiek" },
                    { 2, "日", new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7512), new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7513), 4, "Dzień, słońce" }
                });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Created", "KanjiId", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7674), 1, "ジン、ニン", new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7675), "ひと" },
                    { 2, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7678), 2, "ニチ、 ジツ", new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7678), "ひ、び" }
                });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "KanjiId", "LastModified", "ReadingKanjiInSentence", "Sentence", "SentenceKanji", "Translation", "TranslationReadingKanjiInSentence" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7703), 1, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7704), "ひと", "この人はにほんじんです。", "人", "Ten człowiek jest Japończykiem.", "człowiek" },
                    { 2, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7707), 1, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7708), "ひとびと", "なぜ人々はほんをよみますか。", "人々", "Dlaczego ludzie czytają książki?", "ludzie" },
                    { 3, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7710), 2, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7710), "ひ", "ほんとうにいい日でした", "日", "Ten dzień był naprawdę dobry.", "dzień" },
                    { 4, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7712), 2, new DateTime(2024, 1, 27, 19, 6, 31, 788, DateTimeKind.Utc).AddTicks(7713), "ひび", "ともだちとあうとき、むかしの日々をおもいだします。", "日々", "Gdy spotykam się z przyjacielem, przypominają mi się dawne czasy.", "codziennie, dni" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_KanjiId",
                table: "Readings",
                column: "KanjiId",
                unique: true,
                filter: "[KanjiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sentences_KanjiId",
                table: "Sentences",
                column: "KanjiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Kanji");
        }
    }
}
