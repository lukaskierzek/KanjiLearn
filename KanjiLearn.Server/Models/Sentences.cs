using System.ComponentModel.DataAnnotations;

namespace KanjiLearn.Server.Models
{
    public class Sentences
    {
        public int Id { get; set; }
        public string Sentence { get; set; } = null!;
        public string Translation { get; set; } = null!;
        public int KanjiId { get; set; }
        public Kanji Kanji { get; set; } = null!;
    }
}