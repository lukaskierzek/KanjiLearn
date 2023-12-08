using KanjiLearn.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Data
{
    public class KanjiLearnContext : DbContext
    {
        public DbSet<Kanji> Kanji { get; set; } = null!;
        public DbSet<Readings> Readings { get; set; } = null!;
        public DbSet<Sentences> Sentences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kanji>()
                .Property(e => e.Strokes)
                .HasMaxLength(2);

            modelBuilder.Entity<Kanji>()
                .HasOne(e => e.Readings)
                .WithOne(e => e.Kanji)
                .HasForeignKey<Readings>(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<Kanji>()
                .HasMany(e => e.Sentences)
                .WithOne(e => e.Kanji)
                .HasForeignKey(e => e.KanjiId)
                .IsRequired();
        }
    }
}
