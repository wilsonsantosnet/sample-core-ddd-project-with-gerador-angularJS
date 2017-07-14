using Sample.Domain.Validations;
using System;

namespace Sample.Domain.Entitys
{
    public class Teste : TesteBase
    {

        public Teste()
        {

        }

        public Teste(int testeid, string nome) :
            base(testeid, nome)
        {

        }

        public bool IsValid()
        {
            base._validationResult = new TesteEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
