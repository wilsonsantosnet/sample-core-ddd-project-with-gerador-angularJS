using Common.Domain.Base;
using Common.Orm;
using Sample.Data.Context;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using Sample.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Data.Repository
{
    public class TesteRepository : Repository<Teste>, ITesteRepository
    {
        public TesteRepository(DbContextSeed ctx) : base(ctx)
        {


        }

      
        public IQueryable<Teste> GetBySimplefilters(TesteFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters);
            return querybase;
        }

        public async Task<Teste> GetById(TesteFilter model)
        {
            var _teste = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.TesteId == model.TesteId));

            return _teste;
        }

		 public async Task<IEnumerable<dynamic>> GetDataItem(TesteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TesteId

            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(TesteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TesteId,

            }));

            return querybase;
        }

        public async Task<dynamic> GetDataCustom(TesteFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.TesteId,

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Teste> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Teste> source, FilterBase filters)
        {
            if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                //if (!filters.IsOrderByDomain)
                //{
                //    return source.Select(_ => new
                //    {
                //        Id = _.TesteId
                //    }).OrderBy(_ => _.Id);
                //}

                return source.Select(_ => new
                {
                    //Id = _.TesteId
                });

            }

            //if (!filters.IsOrderByDomain)
            //    return source.OrderBy(_ => _.TesteId);

            return source;
        }

        protected override IQueryable<Teste> MapperGetByFiltersToDomainFields(IQueryable<Teste> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Teste
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Teste)_).AsQueryable();

        }

        protected override Teste MapperGetOneToDomainFields(IQueryable<Teste> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Teste
                {

                };
            }

            return source.SingleOrDefault();
        }

    }
}
