using System.ComponentModel.DataAnnotations;
namespace KanjiLearn.Server.Models
{
    public class Kanji
    {
        public int Id { get; set; }
        public string Character { get; set; } = null!;
        public string Translation { get; set; } = null!;
        public int Strokes { get; set; }
        public Readings? Readings { get; set; }
        public ICollection<Sentences> Sentences { get; } = new List<Sentences>();

    }
}
