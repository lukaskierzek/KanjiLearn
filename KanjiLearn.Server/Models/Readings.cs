using System.ComponentModel.DataAnnotations;

namespace KanjiLearn.Server.Models
{
    public class Readings
    {
        [Key]
        public int Id { get; set; }
        public string Kunyomi { get; set; } = null!;
        public string Onyomi { get; set; } = null!;
        public Kanji Kanji { get; set; } = null!;
    }
}