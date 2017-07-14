using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entitys;

namespace Sample.Data.Map
{
    public abstract class TesteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Teste> type);

        public TesteMapBase(EntityTypeBuilder<Teste> type)
        {
            
            type.ToTable("Teste");
            type.Property(t => t.TesteId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");


            type.HasKey(d => new { d.TesteId, }); 

			CustomConfig(type);
        }
		
    }
}