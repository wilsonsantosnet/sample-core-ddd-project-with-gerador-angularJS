using Common.Domain.Base;
using System;

namespace Sample.Domain.Entitys
{
    public class TesteBase : DomainBase
    {
        public TesteBase()
        {

        }
        public TesteBase(int testeid, string nome)
        {
            this.TesteId = testeid;
            this.Nome = nome;

        }

        public int TesteId { get; protected set; }
        public string Nome { get; protected set; }




    }
}
