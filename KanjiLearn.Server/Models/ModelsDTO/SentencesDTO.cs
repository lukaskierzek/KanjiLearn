namespace KanjiLearn.Server.ModelsDTO
{
    public record SentencesDTO
    {
        public required string Sentence { get; init; }
        public required string Translation { get; init; }
        public required string ReadingKanjiInSentence { get; init; }
        public required string TranslationReadingKanjiInSentence { get; init; }
        public required string SentenceKanji { get; init; }
    }
}