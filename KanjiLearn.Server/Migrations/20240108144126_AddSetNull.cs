using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanjiLearn.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sentences_Kanji_KanjiId",
                table: "Sentences");

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3471), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3477), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3735), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3738), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3739) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3771), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3772) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3775), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3778), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3781), new DateTime(2024, 1, 8, 14, 41, 25, 11, DateTimeKind.Utc).AddTicks(3782) });

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings",
                column: "KanjiId",
                principalTable: "Kanji",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sentences_Kanji_KanjiId",
                table: "Sentences",
                column: "KanjiId",
                principalTable: "Kanji",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sentences_Kanji_KanjiId",
                table: "Sentences");

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2924), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Kanji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3153), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3156), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3186), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3188) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3190), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193) });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3195), new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3196) });

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Kanji_KanjiId",
                table: "Readings",
                column: "KanjiId",
                principalTable: "Kanji",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sentences_Kanji_KanjiId",
                table: "Sentences",
                column: "KanjiId",
                principalTable: "Kanji",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
