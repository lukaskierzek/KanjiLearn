using KanjiLearn.Server.Models;

namespace KanjiLearn.Server
{
    public static class KanjiExtension
    {
        public static bool IsNull(this Kanji kanji) => kanji == null;
    }
}
