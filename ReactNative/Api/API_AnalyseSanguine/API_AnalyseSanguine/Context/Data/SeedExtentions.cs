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

        private static TypeAnalyse CreateTypeAnalyse(int id, string nom)
        {
            return new TypeAnalyse
            {
                IdTypeAnalyse = id,
                Nom = nom
            };
        }

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

            #region TypesAnalyse
            List<TypeAnalyse> typesAnalyse = new List<TypeAnalyse> {
                CreateTypeAnalyse(1, "Albumine"),
                CreateTypeAnalyse(2, "ALT"),
                CreateTypeAnalyse(3, "Bilan lipidique"),
                CreateTypeAnalyse(4, "Bilirubine totale"),
                CreateTypeAnalyse(5, "Calcium total"),
                CreateTypeAnalyse(6, "Cortisol"),
                CreateTypeAnalyse(7, "Cortisol post-dexaméthasone"),
                CreateTypeAnalyse(8, "Créatinine"),
                CreateTypeAnalyse(9, "Créatinine kinase"),
                CreateTypeAnalyse(10, "Électrolytes"),
                CreateTypeAnalyse(11, "Ferritine"),
                CreateTypeAnalyse(12, "Magnésium"),
                CreateTypeAnalyse(13, "Phosphatase alcaline"),
                CreateTypeAnalyse(14, "Phosphore"),
                CreateTypeAnalyse(15, "Protéine C réactive"),
                CreateTypeAnalyse(16, "Protéines totales"),
                CreateTypeAnalyse(17, "TSH et algorithme T4L et T3L"),
            };

            SeedTypesAnalyse(builder, typesAnalyse);
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
