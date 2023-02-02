﻿using API_AnalyseSanguine.Models;
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
        }
    }
}
