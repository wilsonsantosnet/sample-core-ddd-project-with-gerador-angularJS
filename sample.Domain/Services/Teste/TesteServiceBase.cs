using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using Sample.Domain.Interfaces.Repository;
using Sample.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Domain.Services
{
    public class TesteServiceBase : ServiceBase<Teste>
    {
        protected readonly ITesteRepository _rep;
        public TesteServiceBase(ITesteRepository rep, ICache cache)
            : base(cache)
        {
            this._rep = rep;
        }

        public virtual async Task<Teste> GetOne(TesteFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Teste>> GetByFilters(TesteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Teste>> GetByFiltersPaging(TesteFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public virtual void Remove(Teste teste)
        {
            this._rep.Remove(teste);
        }

        public virtual Summary GetSummary(PaginateResult<Teste> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return base._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return base._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return base._validationWarning;
        }

        public override async Task<Teste> Save(Teste teste, bool questionToContinue = false)
        {
            var testeOld = await this.GetOne(new TesteFilter { TesteId = teste.TesteId });
            if (questionToContinue)
            {
                if (base.Continue(teste, testeOld) == false)
                    return teste;
            }

            return this.SaveWithValidation(teste, testeOld);
        }

        public override async Task<Teste> SavePartial(Teste teste, bool questionToContinue = false)
        {
            var testeOld = await this.GetOne(new TesteFilter { TesteId = teste.TesteId });
            if (questionToContinue)
            {
                if (base.Continue(teste, testeOld) == false)
                    return teste;
            }

            return SaveWithOutValidation(teste, testeOld);
        }

        protected override Teste SaveWithOutValidation(Teste teste, Teste testeOld)
        {
            teste = this.SaveDefault(teste, testeOld);

            base._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "teste Alterado com sucesso."
            };

            base._cacheHelper.ClearCache();
            return teste;

        }

		protected override Teste SaveWithValidation(Teste teste, Teste testeOld)
        {
            if (!this.DataAnnotationIsValid())
                return teste;

            if (!teste.IsValid())
            {
                base._validationResult = teste.GetDomainValidation();
                return teste;
            }

            this.Specifications(teste);

            if (!base._validationResult.IsValid)
            {
                return teste;
            }
            
            teste = this.SaveDefault(teste, testeOld);
            base._validationResult.Message = "Teste cadastrado com sucesso :)";

            base._cacheHelper.ClearCache();
            return teste;
        }

		protected virtual void Specifications(Teste teste)
        {
            base._validationResult  = new TesteAptoParaCadastroValidation(this._rep).Validate(teste);
			base._validationWarning  = new TesteAptoParaCadastroWarning(this._rep).Validate(teste);
        }

        protected virtual Teste SaveDefault(Teste teste, Teste testeOld)
        {
            var isNew = testeOld.IsNull();
            if (isNew)
            {
				
                teste = this._rep.Add(teste);
            }
            else
            {
				
				
                teste = this._rep.Update(teste);
            }

            return teste;
        }
    }
}
