using Common.Validation;
using Sample.Domain.Entitys;
using Sample.Domain.Interfaces.Repository;

namespace Sample.Domain.Validations
{
    public class TesteAptoParaCadastroValidation : ValidatorSpecification<Teste>
    {
        public TesteAptoParaCadastroValidation(ITesteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Teste>(Instance of RuleClassName,"message for user"));
        }

    }
}
