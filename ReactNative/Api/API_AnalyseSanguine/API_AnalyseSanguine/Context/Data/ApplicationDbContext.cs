using API_AnalyseSanguine.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AnalyseSanguine.Context.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<RequeteAnalyse> RequeteAnalyses { get; set; }
        public DbSet<ResultatAnalyse> ResultatAnalyses { get; set; }
        public DbSet<TypeAnalyse> TypeAnalyses { get; set; }
        public DbSet<TypeValeur> TypeValeurs { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
