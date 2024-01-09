using AutoMapper;
using KanjiLearn.Server.Data;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;

namespace KanjiLearn.Server.Services
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

        public IEnumerable<KanjiDTO> GetAllKanji(List<Kanji> kanji)
        {
            var kanjiDTOs = _mapper.Map<List<KanjiDTO>>(kanji);
            return kanjiDTOs;
        }

        public KanjiDTO? GetKanji(Kanji kanji)
        {
            if (kanji.IsNull())
                return null;

            var KanjiDTO = _mapper.Map<KanjiDTO>(kanji);
            return KanjiDTO;
        }

        public Kanji CreateKanji(CreateKanjiDTO createKanjiDTO)
        {
            var kanji = _mapper.Map<Kanji>(createKanjiDTO);
            return kanji;
        }

        public bool DeleteKanji(Kanji kanji)
        {
            if (kanji.IsNull())
                return false;

            _context.Kanji.Remove(kanji);
            return true;
        }

        public bool CheckPutKanji(Kanji? kanji, int id, UpdateKanjiDTO updateKanjiDTO)
        {
            bool isBad = false;

            if (kanji.IsNull())
                isBad = true;

            if (kanji.Id != id)
                isBad = true;

            if (!isBad)
                UpdateKanjiByKanjiDTO(kanji, updateKanjiDTO);

            return isBad;
        }

        private static void UpdateKanjiByKanjiDTO(Kanji kanji, UpdateKanjiDTO updateKanjiDTO)
        {
            kanji.Character = updateKanjiDTO.Character;
            kanji.Strokes = updateKanjiDTO.Strokes;
            kanji.Translation = updateKanjiDTO.Translation;
            kanji.Readings.Kunyomi = updateKanjiDTO.Kunyomi;
            kanji.Readings.Onyomi = updateKanjiDTO.Onyomi;
            kanji.LastModified = updateKanjiDTO.LastModified;
        }

        public bool IsAnyKanjiById(int id) => _context.Kanji.Any(e => e.Id == id);
    }
}
