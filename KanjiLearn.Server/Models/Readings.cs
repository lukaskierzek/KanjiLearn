namespace KanjiLearn.Server.Models
{
    public class Readings
    {
        public int Id { get; set; }
        public string Kunyomi { get; set; } = null!;
        public string Onyomi { get; set; } = null!;
        public int KanjiId { get; set; }
        public virtual Kanji Kanji { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}