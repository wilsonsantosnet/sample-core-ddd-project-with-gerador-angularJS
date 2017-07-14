using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using System.Linq;

namespace Sample.Data.Repository
{
    public static class TesteFilterBasicExtension
    {

        public static IQueryable<Teste> WithBasicFilters(this IQueryable<Teste> queryBase, TesteFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.TesteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TesteId == filters.TesteId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};


            return queryFilter;
        }

    }
}