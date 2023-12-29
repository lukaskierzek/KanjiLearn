using System.ComponentModel.DataAnnotations;

namespace KanjiLearn.Server.Models
{
    public class Sentences
    {
        public int Id { get; set; }
        public string Sentence { get; set; } = null!;
        public string Translation { get; set; } = null!;
        public string ReadingKanjiInSentence { get; set; } = null!;
        public string TranslationReadingKanjiInSentence { get; set; } = null!;
        public string SentenceKanji { get; set; } = null!;
        public int KanjiId { get; set; }
        public virtual Kanji Kanji { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }


}