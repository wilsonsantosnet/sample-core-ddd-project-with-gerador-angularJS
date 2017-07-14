using Common.Domain.Interfaces;
using Sample.Domain.Entitys;
using Sample.Domain.Interfaces.Repository;
using Sample.Domain.Interfaces.Services;

namespace Sample.Domain.Services
{
    public class TesteService : TesteServiceBase, ITesteService
    {
        public TesteService(ITesteRepository rep, ICache cache) 
            : base(rep, cache)
        {


        }
        
    }
}
