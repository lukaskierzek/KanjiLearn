using KanjiLearn.Server.Models;

namespace KanjiLearn.Server.Services
{
    public interface IKanjiService
    {
        public IEnumerable<Kanji> Get();
    }
}