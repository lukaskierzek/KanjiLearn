namespace KanjiLearn.Server.ModelsDTO
{
    public record UpdateSentencesDTO
    {
        public required string Sentence { get; init; }
        public required string Translation { get; init; }
        public required string ReadingKanjiInSentence { get; init; }
        public required string TranslationReadingKanjiInSentence { get; init; }
        public required string SentenceKanji { get; init; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}