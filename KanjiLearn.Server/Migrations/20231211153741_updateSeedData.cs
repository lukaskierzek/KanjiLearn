using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanjiLearn.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReadingKanjiInSentence",
                table: "Sentences",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SentenceKanji",
                table: "Sentences",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TranslationReadingKanjiInSentence",
                table: "Sentences",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified", "Strokes" },
                values: new object[] { new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8633), new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8636), 2 });

            migrationBuilder.InsertData(
                table: "Kanji",
                columns: new[] { "Id", "Character", "Created", "LastModified", "Strokes", "Translation" },
                values: new object[] { 2, "日", new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8638), new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8639), 4, "Dzień, słońce" });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[] { new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8997), "ジン、ニン", new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(8998), "ひと" });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified", "ReadingKanjiInSentence", "Sentence", "SentenceKanji", "Translation", "TranslationReadingKanjiInSentence" },
                values: new object[] { new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9029), new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9030), "ひと", "この人はにほんじんです。", "人", "Ten człowiek jest Japończykiem.", "człowiek" });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified", "ReadingKanjiInSentence", "Sentence", "SentenceKanji", "Translation", "TranslationReadingKanjiInSentence" },
                values: new object[] { new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9037), new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9038), "ひとびと", "なぜ人々はほんをよみますか。", "人々", "Dlaczego ludzie czytają książki?", "ludzie" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Created", "KanjiId", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[] { 2, new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9000), 2, "ニチ、 ジツ", new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9000), "ひ、び" });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "KanjiId", "LastModified", "ReadingKanjiInSentence", "Sentence", "SentenceKanji", "Translation", "TranslationReadingKanjiInSentence" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9041), 2, new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9042), "ひ", "ほんとうにいい日でした", "日", "Ten dzień był naprawdę dobry.", "dzień" },
                    { 4, new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9046), 2, new DateTime(2023, 12, 11, 15, 37, 39, 880, DateTimeKind.Utc).AddTicks(9047), "ひび", "ともだちとあうとき、むかしの日々をおもいだします。", "日々", "Gdy spotykam się z przyjacielem, przypominają mi się dawne czasy.", "codziennie, dni" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ReadingKanjiInSentence",
                table: "Sentences");

            migrationBuilder.DropColumn(
                name: "SentenceKanji",
                table: "Sentences");

            migrationBuilder.DropColumn(
                name: "TranslationReadingKanjiInSentence",
                table: "Sentences");

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified", "Strokes" },
                values: new object[] { new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7468), new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7471), 999 });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Kunyomi", "LastModified", "Onyomi" },
                values: new object[] { new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7691), "", new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7692), "" });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified", "Sentence", "Translation" },
                values: new object[] { new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7716), new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7717), "ss1", "tttt1" });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified", "Sentence", "Translation" },
                values: new object[] { new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7719), new DateTime(2023, 12, 10, 21, 21, 54, 881, DateTimeKind.Utc).AddTicks(7721), "ss2", "tttt2" });
        }
    }
}
