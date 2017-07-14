using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entitys;

namespace Sample.Data.Map
{
    public class TesteMap : TesteMapBase
    {
        public TesteMap(EntityTypeBuilder<Teste> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Teste> type)
        {

        }

    }
}