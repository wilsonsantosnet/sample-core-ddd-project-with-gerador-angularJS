using Common.Validation;
using Sample.Domain.Entitys;

namespace Sample.Domain.Validations
{
    public class TesteEstaConsistenteValidation : ValidatorSpecification<Teste>
    {
        public TesteEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Teste>(Instance of RuleClassName,"message for user"));
        }

    }
}
