using AutoMapper;
using KanjiLearn.Server.Models;
using KanjiLearn.Server.ModelsDTO;

namespace KanjiLearn.Server.Mapping
{
    public class KanjiMapping : Profile
    {
        public KanjiMapping()
        {
            CreateMap<Kanji, KanjiDTO>()
                .ForMember(kanjidto => kanjidto.Kunyomi, c => c.MapFrom(kanji => kanji.Readings.Kunyomi))
                .ForMember(kanjidto => kanjidto.Onyomi, c => c.MapFrom(kanji => kanji.Readings.Onyomi));

            CreateMap<CreateKanjiDTO, Kanji>()
                .ForMember(kanji => kanji.Readings,
                    c => c.MapFrom(createkanjidto => new Readings() 
                    {
                        Kunyomi = createkanjidto.Kunyomi,
                        Onyomi = createkanjidto.Onyomi,
                        LastModified = createkanjidto.LastModified,
                        Created = createkanjidto.Created
                    }));
            
            CreateMap<Sentences, SentencesDTO>();
            CreateMap<CreateSentencesDTO, Sentences>();
        }
    }
}
