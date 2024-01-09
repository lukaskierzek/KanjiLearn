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
           
            CreateMap<CreateKanjiDTO, Kanji>()
                .ForMember(kanji => kanji.Readings,
                c => c.MapFrom(ckdto => new Readings()
                {
                    Kunyomi = ckdto.Kunyomi,
                    Onyomi = ckdto.Onyomi,
                    LastModified = ckdto.LastModified,
                    Created = ckdto.Created
                }));

            CreateMap<Sentences, SentencesDTO>();
            CreateMap<CreateSentencesDTO, Sentences>();
        }
    }
}
