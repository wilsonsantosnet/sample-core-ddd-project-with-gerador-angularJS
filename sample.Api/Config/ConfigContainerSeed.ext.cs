using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application;
using Sample.Application.Interfaces;
using Sample.Data.Context;
using Sample.Data.Repository;
using Sample.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Domain.Interfaces.Services;
using Sample.Domain.Services;
using Common.Domain.Model;

namespace Sample.Api
{
    public static partial class ConfigContainerSample 
    {

        public static void RegisterOtherComponents(IServiceCollection services)
        {
			services.AddScoped<CurrentUser>();
        }
    }
}
