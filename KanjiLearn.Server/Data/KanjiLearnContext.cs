using KanjiLearn.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Data
{
    public class KanjiLearnContext : DbContext
    {
        public DbSet<Kanji> Kanji { get; set; } = null!;
        public DbSet<Readings> Readings { get; set; } = null!;
        public DbSet<Sentences> Sentences { get; set; } = null!;

        public KanjiLearnContext(DbContextOptions<KanjiLearnContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Kanji
            modelBuilder.Entity<Kanji>()
                .Property(k => k.Character)
                .HasMaxLength(1);

            modelBuilder.Entity<Kanji>()
                .Property(k => k.Translation)
                .HasMaxLength(255);

            modelBuilder.Entity<Kanji>()
                .Property(k => k.Strokes)
                .HasMaxLength(2);

            modelBuilder.Entity<Kanji>()
                .HasOne(k => k.Readings)
                .WithOne(r => r.Kanji)
                .HasForeignKey<Readings>(r => r.KanjiId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();

            modelBuilder.Entity<Kanji>()
                .HasMany(k => k.Sentences)
                .WithOne(s => s.Kanji)
                .HasForeignKey(e => e.KanjiId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            #endregion

            #region Readings
            modelBuilder.Entity<Readings>()
                .Property(e => e.Kunyomi)
                .HasMaxLength(255);

            modelBuilder.Entity<Readings>()
                .Property(e => e.Onyomi)
                .HasMaxLength(255);
            #endregion

            #region Sentences
            modelBuilder.Entity<Sentences>()
                .Property(e => e.Sentence)
                .HasMaxLength(255);

            modelBuilder.Entity<Sentences>()
                .Property(e => e.Translation)
                .HasMaxLength(255);

            modelBuilder.Entity<Sentences>()
                .Property(e => e.ReadingKanjiInSentence)
                .HasMaxLength(255);

            modelBuilder.Entity<Sentences>()
                .Property(e => e.TranslationReadingKanjiInSentence)
                .HasMaxLength(255);

            modelBuilder.Entity<Sentences>()
                .Property(e => e.SentenceKanji)
                .HasMaxLength(255);
            #endregion

            #region SeedData

            #region SeedDataKanji
            modelBuilder.Entity<Kanji>().HasData(
                        new Kanji
                        {
                            Id = 1,
                            Character = "人",
                            Translation = "Człowiek",
                            Strokes = 2,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                        },
                        new Kanji
                        {
                            Id = 2,
                            Character = "日",
                            Translation = "Dzień, słońce",
                            Strokes = 4,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                        }
                    );
            #endregion

            #region SeedDataReadings
            modelBuilder.Entity<Readings>().HasData(
                        new Readings
                        {
                            Id = 1,
                            Kunyomi = "ジン、ニン",
                            Onyomi = "ひと",
                            KanjiId = 1,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        },
                        new Readings
                        {
                            Id = 2,
                            Kunyomi = "ニチ、 ジツ",
                            Onyomi = "ひ、び",
                            KanjiId = 2,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                        }
                    );
            #endregion

            #region SeedDataSenteces
            modelBuilder.Entity<Sentences>().HasData(
                        new Sentences
                        {
                            Id = 1,
                            Sentence = "この人はにほんじんです。",
                            Translation = "Ten człowiek jest Japończykiem.",
                            ReadingKanjiInSentence = "ひと",
                            TranslationReadingKanjiInSentence = "człowiek",
                            SentenceKanji = "人",
                            KanjiId = 1,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        },
                        new Sentences
                        {
                            Id = 2,
                            Sentence = "なぜ人々はほんをよみますか。",
                            Translation = "Dlaczego ludzie czytają książki?",
                            ReadingKanjiInSentence = "ひとびと",
                            TranslationReadingKanjiInSentence = "ludzie",
                            SentenceKanji = "人々",
                            KanjiId = 1,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        },
                        new Sentences
                        {
                            Id = 3,
                            Sentence = "ほんとうにいい日でした",
                            Translation = "Ten dzień był naprawdę dobry.",
                            ReadingKanjiInSentence = "ひ",
                            TranslationReadingKanjiInSentence = "dzień",
                            SentenceKanji = "日",
                            KanjiId = 2,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        },
                        new Sentences
                        {
                            Id = 4,
                            Sentence = "ともだちとあうとき、むかしの日々をおもいだします。",
                            Translation = "Gdy spotykam się z przyjacielem, przypominają mi się dawne czasy.",
                            ReadingKanjiInSentence = "ひび",
                            TranslationReadingKanjiInSentence = "codziennie, dni",
                            SentenceKanji = "日々",
                            KanjiId = 2,
                            Created = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow
                        }
                    );
            #endregion
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
