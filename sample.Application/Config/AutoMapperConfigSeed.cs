using AutoMapper;

namespace Sample.Application.Config
{
	public class AutoMapperConfigSample
    {
		public static void RegisterMappings()
		{

			Mapper.Initialize(x =>
			{
				x.AddProfile<DominioToDtoProfileSeed>();
				x.AddProfile<DominioToDtoProfileSeedCustom>();
			});

		}
	}
}
