using AutoMapper;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.Data;
using KanjiLearn.Server.ModelsDTO;
using KanjiLearn.Server.Models.Extensions;

namespace KanjiLearn.Server.Services.KanjiService
{
    public class KanjiService : IKanjiService
    {
        private readonly KanjiLearnContext _context;
        private readonly IMapper _mapper;

        public KanjiService(KanjiLearnContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<KanjiDTO> GetAllKanjiDTO(List<Kanji> kanji) => _mapper.Map<List<KanjiDTO>>(kanji);

        public KanjiDTO GetKanjiDTO(Kanji kanji) => _mapper.Map<KanjiDTO>(kanji);

        public Kanji CreateKanji(CreateKanjiDTO createKanjiDTO) => _mapper.Map<Kanji>(createKanjiDTO);

        public bool DeleteKanji(Kanji kanji)
        {
            if (kanji.IsNull())
                return false;

            _context.Kanji.Remove(kanji);
            return true;
        }

        public void UpdateKanjiByKanjiDTO(Kanji kanji, int id, UpdateKanjiDTO updateKanjiDTO)
        {
            kanji.Character = updateKanjiDTO.Character;
            kanji.Strokes = updateKanjiDTO.Strokes;
            kanji.Translation = updateKanjiDTO.Translation;
            kanji.Readings.Kunyomi = updateKanjiDTO.Kunyomi;
            kanji.Readings.Onyomi = updateKanjiDTO.Onyomi;
            kanji.LastModified = updateKanjiDTO.LastModified;
        }

        public bool IsAnyKanjiById(int id) => _context.Kanji.Any(kanji => kanji.Id == id);
    }
}
