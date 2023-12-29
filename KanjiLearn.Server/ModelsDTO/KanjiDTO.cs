using KanjiLearn.Server.Models;

namespace KanjiLearn.Server.ModelsDTO
{
    public record KanjiDTO
    {
        public required int Id { get; init; }
        public required string Character { get; init; }
        public required string Translation { get; init; }
        public required int Strokes { get; init; }
        public required string Kunyomi { get; set; } = null!;
        public required string Onyomi { get; set; } = null!;
        public required ICollection<SentencesDTO> Sentences { get; init; }
    }
}
