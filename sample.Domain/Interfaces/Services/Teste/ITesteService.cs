using Common.Domain.Interfaces;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;

namespace Sample.Domain.Interfaces.Services
{
    public interface ITesteService : IServiceBase<Teste, TesteFilter>
    {

        
    }
}
