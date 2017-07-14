using Common.Domain.Model;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using System.Linq;

namespace Sample.Data.Repository
{
    public static class TesteFilterCustomExtension
    {

        public static IQueryable<Teste> WithCustomFilters(this IQueryable<Teste> queryBase, TesteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Teste> WithLimitSubscriber(this IQueryable<Teste> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

