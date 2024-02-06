using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;

namespace KanjiLearn.Server.Services.KanjiService
{
    public interface IKanjiService
    {
        IEnumerable<KanjiDTO> GetAllKanji(List<Kanji> kanji);
        KanjiDTO GetKanji(Kanji kanji);
        Kanji CreateKanji(CreateKanjiDTO createKanjiDTO);
        bool DeleteKanji(Kanji kanji);
        bool IsAnyKanjiById(int id);
        void UpdateKanjiByKanjiDTO(Kanji? kanji, int id, UpdateKanjiDTO updateKanjiDTO);
    }
}
