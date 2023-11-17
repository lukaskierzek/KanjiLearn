using System.ComponentModel.DataAnnotations;

namespace KanjiLearn.Server.Models
{
    public class Sentences
    {
        [Key]
        public int Id { get; set; }
        public string Sentence { get; set; } = null!;
        public string Translation { get; set; } = null!;
        public Kanji Kanji { get; set; } = null!;
    }
}