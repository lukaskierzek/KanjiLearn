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

        public KanjiDTO GetKanji(Kanji kanji)
        {
            if (kanji == null)
                return null;

            var KanjiDTO = _mapper.Map<KanjiDTO>(kanji);
            return KanjiDTO;
        }
    }
}
