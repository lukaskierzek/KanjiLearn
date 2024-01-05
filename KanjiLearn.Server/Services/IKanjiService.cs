using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace KanjiLearn.Server.Services
{
    public interface IKanjiService
    {
        IEnumerable<KanjiDTO> GetAllKanji(List<Kanji> kanji);
        KanjiDTO GetKanji(Kanji kanji);
        Kanji CreateKanji(CreateKanjiDTO createKanjiDTO);
        bool DeleteKanji(Kanji kanji);
    }
}