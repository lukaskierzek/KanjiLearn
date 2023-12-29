namespace KanjiLearn.Server.ModelsDTO
{
    public record ReadingsDTO
    {
        public required int Id { get; init; }
        public required string Kunyomi { get; init; }
        public required string Onyomi { get; init; }
    }
}
