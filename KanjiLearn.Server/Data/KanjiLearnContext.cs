using KanjiLearn.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KanjiLearn.Server.Data
{
    public class KanjiLearnContext : DbContext
    {
        public DbSet<Kanji> Kanji { get; set; } = null!;
        public DbSet<Readings> Readings { get; set; } = null!;
        public DbSet<Sentences> Sentences { get; set; } = null!;
    }
}
