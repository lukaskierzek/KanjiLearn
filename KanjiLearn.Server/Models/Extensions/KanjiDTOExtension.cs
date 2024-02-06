using KanjiLearn.Server.ModelsDTO;

namespace KanjiLearn.Server.Models.Extensions
{
    public static class KanjiDTOExtension
    {
        public static bool IsNull(this KanjiDTO kanjiDTO) => kanjiDTO == null; 
    }
}
