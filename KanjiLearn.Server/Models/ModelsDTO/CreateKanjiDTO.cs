namespace KanjiLearn.Server.ModelsDTO
{
    public record CreateKanjiDTO
    {
        public required string Character { get; init; }
        public required string Translation { get; init; }
        public required int Strokes { get; init; }
        public required string Kunyomi { get; set; }
        public required string Onyomi { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}