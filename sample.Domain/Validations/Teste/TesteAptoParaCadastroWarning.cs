using Common.Validation;
using Sample.Domain.Entitys;
using Sample.Domain.Interfaces.Repository;

namespace Sample.Domain.Validations
{
    public class TesteAptoParaCadastroWarning : WarningSpecification<Teste>
    {
        public TesteAptoParaCadastroWarning(ITesteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Teste>(Instance of RuleClassName,"message for user"));
        }

    }
}
