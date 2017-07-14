using Microsoft.EntityFrameworkCore;
using Sample.Data.Map;
using Sample.Domain.Entitys;

namespace Sample.Data.Context
{
    public class DbContextSeed : DbContext
    {

        public DbContextSeed(DbContextOptions<DbContextSeed> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        new TesteMap(modelBuilder.Entity<Teste>());

        }


    }
}
