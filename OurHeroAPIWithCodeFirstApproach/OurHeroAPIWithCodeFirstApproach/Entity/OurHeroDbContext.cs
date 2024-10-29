using Microsoft.EntityFrameworkCore;
using OurHeroAPIWithCodeFirstApproach.Model;

namespace OurHeroAPIWithCodeFirstApproach.Entity
{
    public class OurHeroDbContext : DbContext
    {
        public OurHeroDbContext(DbContextOptions<OurHeroDbContext> options) : base(options)
        { }
        public DbSet<OurHero> OurHeros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<OurHero>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<OurHero>().HasData(
                new OurHero
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    IsActive = true,
                }
            );

        }

    }
}
