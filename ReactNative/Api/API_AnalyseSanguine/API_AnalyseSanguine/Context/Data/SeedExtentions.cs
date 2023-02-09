using API_AnalyseSanguine.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_AnalyseSanguine.Context.Data
{
    public static class SeedExtentions
    {
        private static Medecin CreateMedecin(int id, string firstName, string lastName)
        {
            return new Medecin
            {
                IdMedecin= id,
                Nom= lastName,
                Prenom= firstName
            };
        }

        private static void SeedMedecins(this ModelBuilder builder, IEnumerable<Medecin> medecins)
        { builder.Entity<Medecin>().HasData(medecins); }

        private static Dossier CreateDossier(int id, DateTime dateNaissance, string lastName, string firstName, byte sexe)
        {
            return new Dossier
            {
                IdDossier = id,
                DateNaissance = dateNaissance,
                Nom = lastName,
                Prenom = firstName,
                Sexe = sexe,
            };
        }

        private static void SeedDossiers(this ModelBuilder builder, IEnumerable<Dossier> dossiers)
        { builder.Entity<Dossier>().HasData(dossiers); }

        private static TypeAnalyse CreateTypeAnalyse(int id, string nom, Category category)
        {
            return new TypeAnalyse
            {
                IdTypeAnalyse = id,
                Nom = nom,
                CategoryId = category.Id,
            };
        }

        private static TypeValeur CreateTypeValeur(int id, string nom, TypeAnalyse typeAnalyse, string reference)
        {
            return new TypeValeur
            {
                IdTypeValeur = id,
                Nom= nom,
                TypeAnalyse = typeAnalyse,
                Reference=reference
            };
        }

        private static void SeedTypesValeur(this ModelBuilder builder, IEnumerable<TypeAnalyse> typeValeurs)
        { builder.Entity<TypeValeur>().HasData(typeValeurs); }

        private static void SeedTypesAnalyse(this ModelBuilder builder, IEnumerable<TypeAnalyse> typesAnalyse)
        { builder.Entity<TypeAnalyse>().HasData(typesAnalyse); }

        private static RequeteAnalyse CreateRequeteAnalyse(int id, Guid guid, DateTime date, string analyse, string nom, int idDossier, int idMedecin)
        {
            return new RequeteAnalyse
            {
                IdRequete = id,
                CodeAcces = guid,
                DateEchantillon = date,
                AnalyseDemande = analyse,
                NomTechnicien = nom,
                DossierIdDossier = idDossier,
                MedecinIdMedecin = idMedecin
            };
        }

        private static Category CreateCategory(int id, string Name)
        {
            return new Category
            {
                Id = id,
                Name = Name
            };
        }

        private static void SeedCategories(this ModelBuilder builder, IEnumerable<Category> categories)
        { builder.Entity<Category>().HasData(categories); }

        private static void SeedRequeteAnalyse(this ModelBuilder builder, IEnumerable<RequeteAnalyse> requeteAnalyses)
        { builder.Entity<RequeteAnalyse>().HasData(requeteAnalyses); }

        public static void Seed(this ModelBuilder builder)
        {
            #region Médecins
            List<Medecin> medecins = new List<Medecin> {
                CreateMedecin(1, "Zacharie", "Banville"),
                CreateMedecin(2, "Yannick", "Bourque"),
                CreateMedecin(3, "Jonathan", "Langlais"),
                CreateMedecin(4, "Antony", "Jetté"),
                CreateMedecin(5, "Lucas", "Denis"),
                CreateMedecin(6, "Mathilde", "Lagacé"),
                CreateMedecin(7, "Alicia", "Néron"),
                CreateMedecin(8, "Raphaelle", "Godin"),
                CreateMedecin(9, "Leonie", "Martinez"),
                CreateMedecin(10, "Rose", "Daneau")
            };

            SeedMedecins(builder, medecins);
            #endregion

            #region Dossiers
            List<Dossier> dossiers = new List<Dossier> {
                CreateDossier(1, new DateTime(2001, 02, 13), "Turgeon", "Victor", 0),
                CreateDossier(2, new DateTime(2002, 11, 14), "Belval", "Jean-Philippe", 0),
            };

            SeedDossiers(builder, dossiers);
            #endregion


            #region Categories
            List<Category> categories = new List<Category>
            {
                CreateCategory(1, "Hémostase"),
                CreateCategory(2, "Hématologie"),
            };

            SeedCategories(builder, categories);

            #endregion

            #region TypesAnalyse
            List<TypeAnalyse> typesAnalyse = new List<TypeAnalyse> {
                //CreateTypeAnalyse(1, "Albumine"),
                //CreateTypeAnalyse(2, "ALT"),
                //CreateTypeAnalyse(3, "Bilan lipidique"),
                //CreateTypeAnalyse(4, "Bilirubine totale"),
                //CreateTypeAnalyse(5, "Calcium total"),
                //CreateTypeAnalyse(6, "Cortisol"),
                //CreateTypeAnalyse(7, "Cortisol post-dexaméthasone"),
                //CreateTypeAnalyse(8, "Créatinine"),
                //CreateTypeAnalyse(9, "Créatinine kinase"),
                //CreateTypeAnalyse(10, "Électrolytes"),
                //CreateTypeAnalyse(11, "Ferritine"),
                //CreateTypeAnalyse(12, "Magnésium"),
                //CreateTypeAnalyse(13, "Phosphatase alcaline"),
                //CreateTypeAnalyse(14, "Phosphore"),
                //CreateTypeAnalyse(15, "Protéine C réactive"),
                //CreateTypeAnalyse(16, "Protéines totales"),
                //CreateTypeAnalyse(17, "TSH et algorithme T4L et T3L"),

                //Hémostase
                CreateTypeAnalyse(18, "TS", categories[0]),
                CreateTypeAnalyse(19, "To", categories[0]),
                CreateTypeAnalyse(20, "PTT", categories[0]),
                CreateTypeAnalyse(21, "PT", categories[0]),
                CreateTypeAnalyse(22, "TT", categories[0]),
                CreateTypeAnalyse(23, "Fibrinogène", categories[0]),
                CreateTypeAnalyse(24, "Facteur", categories[0]),
                CreateTypeAnalyse(25, "D-dimères", categories[0]),
                CreateTypeAnalyse(26, "fVW", categories[0]),
                CreateTypeAnalyse(27, "LA Screen", categories[0]),
                CreateTypeAnalyse(28, "Anti-Xa", categories[0]),
                CreateTypeAnalyse(29, "Prt C", categories[0]),
                CreateTypeAnalyse(30, "Prt S", categories[0]),
                CreateTypeAnalyse(31, "PLG", categories[0]),
                CreateTypeAnalyse(32, "AP", categories[0]),

                //Hématologie
                CreateTypeAnalyse(33, "FSC num.", categories[1]),
                CreateTypeAnalyse(34, "Plt", categories[1]),
                CreateTypeAnalyse(35, "Micro", categories[1]),
                CreateTypeAnalyse(36, "VS", categories[1]),
                CreateTypeAnalyse(37, "FSC diff.", categories[1]),
            };



            SeedTypesAnalyse(builder, typesAnalyse);
            #endregion

            #region TypeValeur
            List<TypeValeur> typeValeurs = new List<TypeValeur>()
            {
                //Hémostase
                CreateTypeValeur(1, "TS", typesAnalyse.First(x=>x.Nom == "TS"), "4-8 min"),
                CreateTypeValeur(2, "To", typesAnalyse.First(x=>x.Nom == "To"), "EPI: 80-150 secs,ADP: 60-100 secs"),
                CreateTypeValeur(3, "PTT", typesAnalyse.First(x=>x.Nom == "PTT"), "22.0-40.0 secs"),
                CreateTypeValeur(4, "PT", typesAnalyse.First(x=>x.Nom == "PT"), "11.0-14.0 secs"),
                CreateTypeValeur(5, "TT", typesAnalyse.First(x=>x.Nom == "TT"), "≤ 24.0 secs"),
                CreateTypeValeur(6, "Fibrinogène", typesAnalyse.First(x=>x.Nom == "Fibrinogène"), "2.0-4.0 g/L"),
                CreateTypeValeur(7, "Facteur", typesAnalyse.First(x=>x.Nom == "Facteur"), "50-150 %"),
                CreateTypeValeur(8, "D-dimères", typesAnalyse.First(x=>x.Nom == "D-dimères"), "<0.50 µg/mL"),
                CreateTypeValeur(9, "fVW", typesAnalyse.First(x=>x.Nom == "fVW"), "50-160 %"),
                CreateTypeValeur(10, "LA Screen", typesAnalyse.First(x=>x.Nom == "LA Screen"), "≥1.20"),
                CreateTypeValeur(11, "Anti-Xa", typesAnalyse.First(x=>x.Nom == "Anti-Xa"), "0.50-1.00 Ul-mL"),
                CreateTypeValeur(12, "Prt C", typesAnalyse.First(x=>x.Nom == "Prt C"), "70-130 %"),
                CreateTypeValeur(13, "Prt S", typesAnalyse.First(x=>x.Nom == "Prt S"), "70-130 %"),
                CreateTypeValeur(14, "PLG", typesAnalyse.First(x=>x.Nom == "PLG"), "80-120 %"),
                CreateTypeValeur(15, "AP", typesAnalyse.First(x=>x.Nom == "AP"), "80-120 %"),
                //Hématologie

            };
            #endregion

            List<RequeteAnalyse> requetes = new List<RequeteAnalyse>
            {
                CreateRequeteAnalyse(1, Guid.NewGuid(), new DateTime(2022, 07, 14), "", "Matheo Boudreau", dossiers[0].IdDossier, medecins[0].IdMedecin),
                CreateRequeteAnalyse(2, Guid.NewGuid(), new DateTime(2017, 08, 19), "", "Jerome Frenette", dossiers[0].IdDossier, medecins[6].IdMedecin),
                CreateRequeteAnalyse(3, Guid.NewGuid(), new DateTime(2001, 02, 01), "", "Clara Faubert", dossiers[0].IdDossier, medecins[2].IdMedecin),
                CreateRequeteAnalyse(4, Guid.NewGuid(), new DateTime(2014, 12, 25), "", "Louis Truchon", dossiers[1].IdDossier, medecins[9].IdMedecin),
                CreateRequeteAnalyse(5, Guid.NewGuid(), new DateTime(2006, 04, 24), "", "Andreanne Pearson", dossiers[1].IdDossier, medecins[3].IdMedecin),
                CreateRequeteAnalyse(6, Guid.NewGuid(), new DateTime(2009, 09, 05), "", "Sabrina Beauvais", dossiers[1].IdDossier, medecins[8].IdMedecin),
            };

            SeedRequeteAnalyse(builder, requetes);
        }
    }
}
