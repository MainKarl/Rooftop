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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TypeAnalyse>().HasData(
                #region Biochimie
                new TypeAnalyse { IdTypeAnalyse = 1, Nom = "Albumine"   },
                new TypeAnalyse { IdTypeAnalyse = 2, Nom = "ALT"},
                new TypeAnalyse { IdTypeAnalyse = 3, Nom = "Bilan lipidique"},
                new TypeAnalyse { IdTypeAnalyse = 4, Nom = "Bilirubine totale" },
                new TypeAnalyse { IdTypeAnalyse = 5, Nom = "Calcium total" },
                new TypeAnalyse { IdTypeAnalyse = 6, Nom = "Cortisol" },
                new TypeAnalyse { IdTypeAnalyse = 7, Nom = "Cortisol post-dexaméthasone" },
                new TypeAnalyse { IdTypeAnalyse = 8, Nom = "Créatinine" },
                new TypeAnalyse { IdTypeAnalyse = 9, Nom = "Créatinine kinase" },
                new TypeAnalyse { IdTypeAnalyse = 10, Nom = "Électrolytes" },
                new TypeAnalyse { IdTypeAnalyse = 11, Nom = "Ferritine" },
                new TypeAnalyse { IdTypeAnalyse = 12, Nom = "Magnésium" },
                new TypeAnalyse { IdTypeAnalyse = 13, Nom = "Phosphatase alcaline" },
                new TypeAnalyse { IdTypeAnalyse = 14, Nom = "Phosphore" },
                new TypeAnalyse { IdTypeAnalyse = 15, Nom = "Protéine C réactive" },
                new TypeAnalyse { IdTypeAnalyse = 16, Nom = "Protéines totales" },
                new TypeAnalyse { IdTypeAnalyse = 17, Nom = "TSH et algorithme T4L et T3L" }
                #endregion
                );
                
            #region Mecedin
            builder.Entity<Medecin>().HasData(
                new Medecin
                {
                    IdMedecin = 1,
                    Prenom = "Zacharie",
                    Nom = "Banville"
                },
                new Medecin
                {
                    IdMedecin = 2,
                    Prenom = "Yannick",
                    Nom = "Bourque"
                },
                new Medecin
                {
                    IdMedecin = 3,
                    Prenom = "Jonathan",
                    Nom = "Langlais"
                },
                new Medecin
                {
                    IdMedecin = 4,
                    Prenom = "Antony",
                    Nom = "Jetté"
                },
                new Medecin
                {
                    IdMedecin = 5,
                    Prenom = "Lucas",
                    Nom = "Denis"
                },
                new Medecin
                {
                    IdMedecin = 6,
                    Prenom = "Mathilde",
                    Nom = "Lagacé"
                },
                new Medecin
                {
                    IdMedecin = 7,
                    Prenom = "Alicia",
                    Nom = "Néron"
                },
                new Medecin
                {
                    IdMedecin = 8,
                    Prenom = "Raphaelle",
                    Nom = "Godin"
                },
                new Medecin
                {
                    IdMedecin = 9,
                    Prenom = "Leonie",
                    Nom = "Martinez"
                },
                new Medecin
                {
                    IdMedecin = 10,
                    Prenom = "Rose",
                    Nom = "Daneau"
                });
            #endregion
        }
    }
}
