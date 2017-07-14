using Common.Domain.Model;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using System.Linq;

namespace Sample.Data.Repository
{
    public static class TesteOrderCustomExtension
    {

        public static IQueryable<Teste> OrderByDomain(this IQueryable<Teste> queryBase, TesteFilter filters)
        {
            return queryBase.OrderBy(_ => _.TesteId);
        }

    }
}

