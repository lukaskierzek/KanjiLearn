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

    public record KanjiDTO(string Character, string Translation, int Strokes);
}
