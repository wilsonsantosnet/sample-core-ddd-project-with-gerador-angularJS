using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Sample.Application.Interfaces;
using Sample.Domain.Entitys;
using Sample.Domain.Filter;
using Sample.Domain.Interfaces.Services;
using Sample.Dto;
using System.Threading.Tasks;

namespace Sample.Application
{
    public class TesteApplicationServiceBase : ApplicationServiceBase<Teste, TesteDto, TesteFilter>, ITesteApplicationService
    {
        protected readonly ValidatorAnnotations<TesteDto> _validatorAnnotations;
        protected readonly ITesteService _service;

        public TesteApplicationServiceBase(ITesteService service, IUnitOfWork uow, ICache cache) :
            base(service, uow, cache)
        {
            base.SetTagNameCache("Teste");
            this._validatorAnnotations = new ValidatorAnnotations<TesteDto>();
            this._service = service;
        }


        protected override Teste MapperDtoToDomain<TDS>(TDS dto)
        {
			var _dto = dto as TesteDto;
            this._validatorAnnotations.Validate(_dto);
            this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());

            var domain = new Teste(_dto.TesteId,
                                        _dto.Nome);



            return domain;
        }


        protected override async Task<Teste> AlterDomainWithDto<TDS>(TDS dto)
        {
			var teste = dto as TesteDto;
            var result = await this._serviceBase.GetOne(new TesteFilter { TesteId = teste.TesteId });

            //Inicio da Transferencia dos valores
           

            //Fim da Transferencia dos valores

            return result;
        }

    }
}
