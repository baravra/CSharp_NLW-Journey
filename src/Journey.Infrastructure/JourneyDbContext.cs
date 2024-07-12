using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure
{
    public class JourneyDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        //public DbSet<Trip> TesteTripsNomeDiferente { get; set; } // caso queira dar um nome diferente 1/2
        public DbSet<Activity> Activities { get; set; } // acesso direto e  linka-las em sua respectiva trip
        
        // tabela de entidades viagem que quero acessar
        // acesso direto à tabela de viagens

        // onde ta o BD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\NLW Journey\\JourneyDatabase.db");
        }

        //=== Comentada pois foi feito acesso direto por causa da FK (sqLite nao aceita)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // A entidade Activity vai pegar ela da tabela activities
        //    modelBuilder.Entity<Activity>().ToTable("Activities");
        //    //modelBuilder.Entity<Trip>().ToTable("Trips"); 2/2
        //}
    }
}
