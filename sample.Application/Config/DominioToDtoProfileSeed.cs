using Sample.Domain.Entitys;
using Sample.Dto;

namespace Sample.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(Teste), typeof(TesteDto)).ReverseMap();
            CreateMap(typeof(Teste), typeof(TesteDtoSpecialized));
            CreateMap(typeof(Teste), typeof(TesteDtoSpecializedResult));
            CreateMap(typeof(Teste), typeof(TesteDtoSpecializedReport));
            CreateMap(typeof(Teste), typeof(TesteDtoSpecializedDetails));

        }

    }
}
