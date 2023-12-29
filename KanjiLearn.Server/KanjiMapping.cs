using AutoMapper;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;

namespace KanjiLearn.Server
{
    public class KanjiMapping : Profile
    {
        public KanjiMapping()
        {
            CreateMap<Kanji, KanjiDTO>()
                .ForMember(kdto => kdto.Kunyomi, c => c.MapFrom(k => k.Readings.Kunyomi))
                .ForMember(kdto => kdto.Onyomi, c => c.MapFrom(k => k.Readings.Onyomi));

            CreateMap<Sentences, SentencesDTO>();
        }
    }
}
