using Common.Domain.Interfaces;
using Sample.Application.Interfaces;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using Sample.Domain.Interfaces.Services;
using Sample.Dto;
using System.Linq;

namespace Sample.Application
{
    public class TesteApplicationService : TesteApplicationServiceBase
    {

        public TesteApplicationService(ITesteService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
  
        }


    }
}
