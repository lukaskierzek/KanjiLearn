using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanjiLearn.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kanji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Character = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    Translation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Strokes = table.Column<int>(type: "integer", maxLength: 2, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kunyomi = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Onyomi = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    KanjiId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Kanji_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sentence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Translation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReadingKanjiInSentence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TranslationReadingKanjiInSentence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SentenceKanji = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    KanjiId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentences_Kanji_KanjiId",
                        column: x => x.KanjiId,
                        principalTable: "Kanji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kanji",
                columns: new[] { "Id", "Character", "Created", "LastModified", "Strokes", "Translation" },
                values: new object[,]
                {
                    { 1, "人", new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2924), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2931), 2, "Człowiek" },
                    { 2, "日", new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934), 4, "Dzień, słońce" }
                });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Created", "KanjiId", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3153), 1, "ジン、ニン", new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3154), "ひと" },
                    { 2, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3156), 2, "ニチ、 ジツ", new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3157), "ひ、び" }
                });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "KanjiId", "LastModified", "ReadingKanjiInSentence", "Sentence", "SentenceKanji", "Translation", "TranslationReadingKanjiInSentence" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3186), 1, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3188), "ひと", "この人はにほんじんです。", "人", "Ten człowiek jest Japończykiem.", "człowiek" },
                    { 2, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3190), 1, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3191), "ひとびと", "なぜ人々はほんをよみますか。", "人々", "Dlaczego ludzie czytają książki?", "ludzie" },
                    { 3, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193), 2, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193), "ひ", "ほんとうにいい日でした", "日", "Ten dzień był naprawdę dobry.", "dzień" },
                    { 4, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3195), 2, new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3196), "ひび", "ともだちとあうとき、むかしの日々をおもいだします。", "日々", "Gdy spotykam się z przyjacielem, przypominają mi się dawne czasy.", "codziennie, dni" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_KanjiId",
                table: "Readings",
                column: "KanjiId",
                unique: true);

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
