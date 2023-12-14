using System.ComponentModel.DataAnnotations;
namespace KanjiLearn.Server.Models
{
    public class Kanji
    {
        public int Id { get; set; }
        public string Character { get; set; } = null!;
        public string Translation { get; set; } = null!;
        public int Strokes { get; set; }
        public virtual Readings Readings { get; set; } = null!;
        public virtual ICollection<Sentences> Sentences { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }

    public record KanjiDTO
    {
        public required string Character { get; init; }
        public required string Translation { get; init; }
        public required int Strokes { get; init; }
        public required DateTime Created { get; init; } = DateTime.UtcNow;
        public required DateTime LastModified { get; init; }
    };
}
