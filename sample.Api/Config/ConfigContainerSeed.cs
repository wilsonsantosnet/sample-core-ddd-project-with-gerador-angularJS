using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application;
using Sample.Application.Interfaces;
using Sample.Data.Context;
using Sample.Data.Repository;
using Sample.Domain.Interfaces.Repository;
using Sample.Domain.Interfaces.Services;
using Sample.Domain.Services;

namespace Sample.Api
{
    public static partial class ConfigContainerSample
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ICache, RedisComponent>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextSeed>>();
            
			services.AddScoped<ITesteApplicationService, TesteApplicationService>();
			services.AddScoped<ITesteService, TesteService>();
			services.AddScoped<ITesteRepository, TesteRepository>();



            RegisterOtherComponents(services);
        }
    }
}
