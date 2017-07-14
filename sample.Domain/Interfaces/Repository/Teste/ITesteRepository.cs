using Common.Domain.Interfaces;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces.Repository
{
    public interface ITesteRepository : IRepository<Teste>
    {
        IQueryable<Teste> GetBySimplefilters(TesteFilter filters);

        Task<Teste> GetById(TesteFilter teste);
		
        Task<IEnumerable<dynamic>> GetDataItem(TesteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TesteFilter filters);

        Task<dynamic> GetDataCustom(TesteFilter filters);
    }
}
