namespace KanjiLearn.Server.Models.Extensions
{
    public static class KanjiExtension
    {
        public static bool IsNull(this Kanji kanji) => kanji == null;
        public static bool IsDifferentId(this Kanji kanji, int id) => kanji.Id != id;
    }
}
