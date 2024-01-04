﻿// <auto-generated />
using System;
using KanjiLearn.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KanjiLearn.Server.Migrations
{
    [DbContext(typeof(KanjiLearnContext))]
    [Migration("20240104110125_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KanjiLearn.Server.Models.Kanji", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Strokes")
                        .HasMaxLength(2)
                        .HasColumnType("integer");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Kanji");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Character = "人",
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2924),
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2931),
                            Strokes = 2,
                            Translation = "Człowiek"
                        },
                        new
                        {
                            Id = 2,
                            Character = "日",
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934),
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(2934),
                            Strokes = 4,
                            Translation = "Dzień, słońce"
                        });
                });

            modelBuilder.Entity("KanjiLearn.Server.Models.Readings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("KanjiId")
                        .HasColumnType("integer");

                    b.Property<string>("Kunyomi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Onyomi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId")
                        .IsUnique();

                    b.ToTable("Readings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3153),
                            KanjiId = 1,
                            Kunyomi = "ジン、ニン",
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3154),
                            Onyomi = "ひと"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3156),
                            KanjiId = 2,
                            Kunyomi = "ニチ、 ジツ",
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3157),
                            Onyomi = "ひ、び"
                        });
                });

            modelBuilder.Entity("KanjiLearn.Server.Models.Sentences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("KanjiId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReadingKanjiInSentence")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("SentenceKanji")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("TranslationReadingKanjiInSentence")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("Sentences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3186),
                            KanjiId = 1,
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3188),
                            ReadingKanjiInSentence = "ひと",
                            Sentence = "この人はにほんじんです。",
                            SentenceKanji = "人",
                            Translation = "Ten człowiek jest Japończykiem.",
                            TranslationReadingKanjiInSentence = "człowiek"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3190),
                            KanjiId = 1,
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3191),
                            ReadingKanjiInSentence = "ひとびと",
                            Sentence = "なぜ人々はほんをよみますか。",
                            SentenceKanji = "人々",
                            Translation = "Dlaczego ludzie czytają książki?",
                            TranslationReadingKanjiInSentence = "ludzie"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193),
                            KanjiId = 2,
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3193),
                            ReadingKanjiInSentence = "ひ",
                            Sentence = "ほんとうにいい日でした",
                            SentenceKanji = "日",
                            Translation = "Ten dzień był naprawdę dobry.",
                            TranslationReadingKanjiInSentence = "dzień"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3195),
                            KanjiId = 2,
                            LastModified = new DateTime(2024, 1, 4, 11, 1, 24, 393, DateTimeKind.Utc).AddTicks(3196),
                            ReadingKanjiInSentence = "ひび",
                            Sentence = "ともだちとあうとき、むかしの日々をおもいだします。",
                            SentenceKanji = "日々",
                            Translation = "Gdy spotykam się z przyjacielem, przypominają mi się dawne czasy.",
                            TranslationReadingKanjiInSentence = "codziennie, dni"
                        });
                });

            modelBuilder.Entity("KanjiLearn.Server.Models.Readings", b =>
                {
                    b.HasOne("KanjiLearn.Server.Models.Kanji", "Kanji")
                        .WithOne("Readings")
                        .HasForeignKey("KanjiLearn.Server.Models.Readings", "KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kanji");
                });

            modelBuilder.Entity("KanjiLearn.Server.Models.Sentences", b =>
                {
                    b.HasOne("KanjiLearn.Server.Models.Kanji", "Kanji")
                        .WithMany("Sentences")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kanji");
                });

            modelBuilder.Entity("KanjiLearn.Server.Models.Kanji", b =>
                {
                    b.Navigation("Readings")
                        .IsRequired();

                    b.Navigation("Sentences");
                });
#pragma warning restore 612, 618
        }
    }
}