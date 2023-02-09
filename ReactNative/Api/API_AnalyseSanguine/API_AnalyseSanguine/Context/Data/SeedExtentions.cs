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
                Category = category,
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
                CreateCategory(3, "Analyse de biochimie"),
                CreateCategory(4, "Routine d'urine"),
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

                // Analyse de biochimie
                CreateTypeAnalyse(38, "ALP", categories[2]),
                CreateTypeAnalyse(39, "ALT", categories[2]),
                CreateTypeAnalyse(40, "Amylase", categories[2]),
                CreateTypeAnalyse(41, "AST", categories[2]),
                CreateTypeAnalyse(42, "GGT", categories[2]),
                CreateTypeAnalyse(43, "Lipase", categories[2]),
                CreateTypeAnalyse(44, "Créatinine sérique", categories[2]),
                CreateTypeAnalyse(45, "Créatinine urinaire", categories[2]),
                CreateTypeAnalyse(46, "Acide urinaire", categories[2]),
                CreateTypeAnalyse(47, "Urée", categories[2]),
                CreateTypeAnalyse(48, "Clairance de la créatinine", categories[2]),
                CreateTypeAnalyse(49, "Bilirubine totale", categories[2]),
                CreateTypeAnalyse(50, "Bilirubine conjuguée", categories[2]),
                CreateTypeAnalyse(51, "Troponine", categories[2]),
                CreateTypeAnalyse(52, "Protéine C-réactive", categories[2]),
                CreateTypeAnalyse(53, "BNP", categories[2]),
                CreateTypeAnalyse(54, "Potassium", categories[2]),
                CreateTypeAnalyse(55, "Sodium", categories[2]),
                CreateTypeAnalyse(56, "Chlorure", categories[2]),
                CreateTypeAnalyse(57, "HCO3", categories[2]),
                CreateTypeAnalyse(58, "pH", categories[2]),
                CreateTypeAnalyse(59, "pCO2", categories[2]),
                CreateTypeAnalyse(60, "PO2", categories[2]),
                CreateTypeAnalyse(61, "Excès de bases", categories[2]),
                CreateTypeAnalyse(62, "Glucose", categories[2]),
                CreateTypeAnalyse(63, "Triglycérides", categories[2]),
                CreateTypeAnalyse(64, "HDL-cholestérol", categories[2]),
                CreateTypeAnalyse(65, "LDL-cholestérol", categories[2]),
                CreateTypeAnalyse(66, "Cholestérol total", categories[2]),
                CreateTypeAnalyse(67, "Protéines totales", categories[2]),
                CreateTypeAnalyse(68, "Albumine", categories[2]),
                CreateTypeAnalyse(69, "b-HCG qualitatif", categories[2]),
                CreateTypeAnalyse(70, "Drogues de rue", categories[2]),
                CreateTypeAnalyse(71, "Éthanol", categories[2]),
                CreateTypeAnalyse(72, "Microscopie urinaire", categories[2]),
                CreateTypeAnalyse(73, "Osmolarité urinaire", categories[2]),
                CreateTypeAnalyse(74, "Osmolarité sérique", categories[2]),

                // Routine urinaire
                 CreateTypeAnalyse(75, "Glucose", categories[3]),
                 CreateTypeAnalyse(76, "Corps cétoniques", categories[3]),
                 CreateTypeAnalyse(77, "Densité", categories[3]),
                 CreateTypeAnalyse(78, "Sang", categories[3]),
                 CreateTypeAnalyse(79, "pH", categories[3]),
                 CreateTypeAnalyse(80, "Protéines", categories[3]),
                 CreateTypeAnalyse(81, "Leucocytes", categories[3]),
                 CreateTypeAnalyse(82, "Nitrites", categories[3]),
                 CreateTypeAnalyse(83, "Bilirubine", categories[3]),
                 CreateTypeAnalyse(84, "Urobilinogène", categories[3]),
            };



            SeedTypesAnalyse(builder, typesAnalyse);
            #endregion

            #region TypeValeur
            List<TypeValeur> typeValeurs = new List<TypeValeur>()
            {
                // Hémostase
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

                // Hémotologie


                // Analyse de biochimie
                CreateTypeValeur(16, "ALP", typesAnalyse.First(x => x.Nom == "ALP"), "<100 U/L *selon l'âge du patient"),
                CreateTypeValeur(17, "ALT", typesAnalyse.First(x => x.Nom == "ALT"), "0-37 U/L"),
                CreateTypeValeur(18, "Amylase", typesAnalyse.First(x => x.Nom == "Amylase"), "<130 U/L"),
                CreateTypeValeur(19, "AST", typesAnalyse.First(x => x.Nom == "AST"), "5-34 U/L"),
                CreateTypeValeur(20, "GGT", typesAnalyse.First(x => x.Nom == "GGT"), "<40 U/L"),
                CreateTypeValeur(21, "Lipase", typesAnalyse.First(x => x.Nom == "Lipase"), "<200 U/L"),
                CreateTypeValeur(22, "Crétinine sérique", typesAnalyse.First(x => x.Nom == "Créatine sérique"), "57-92 umol/L"),
                CreateTypeValeur(23, "Crétinine urinaire", typesAnalyse.First(x => x.Nom == "Crétinine urinaire"), "9-18 mmol/24h"),
                CreateTypeValeur(24, "Acide urique", typesAnalyse.First(x => x.Nom == "Acide urique"), "210-460 umol/L"),
                CreateTypeValeur(25, "Urée", typesAnalyse.First(x => x.Nom == "Urée"), "2.5-6.4 mmol/L"),
                CreateTypeValeur(26, "Clairance de la créatinine", typesAnalyse.First(x => x.Nom == "Clairance de la créatinine"), "1-3 mL/s"),
                CreateTypeValeur(27, "Bilirubine total", typesAnalyse.First(x => x.Nom == "Bilirubine total"), "3.4 - 22 umol/L"),
                CreateTypeValeur(28, "Bilirubine conjugée", typesAnalyse.First(x => x.Nom == "Bilirubine conjugée"), "1.7 - 5 umol/L"),
                CreateTypeValeur(29, "Troponine", typesAnalyse.First(x => x.Nom == "Troponine"), "< 0.4ug/L"),
                CreateTypeValeur(30, "Protéine C-réactive", typesAnalyse.First(x => x.Nom == "Protéine C-réactive"), "< 10mg/L"),
                CreateTypeValeur(31, "BNP", typesAnalyse.First(x => x.Nom == "BNP"), "< 100pg/mL"),
                CreateTypeValeur(32, "Potassium", typesAnalyse.First(x => x.Nom == "Potassium"), "3.5-5 mmol/L"),
                CreateTypeValeur(33, "Sodium", typesAnalyse.First(x => x.Nom == "Sodium"), "135-145 mmol/L"),
                CreateTypeValeur(34, "Chlorure", typesAnalyse.First(x => x.Nom == "Chlorure"), "98-108 mmol/L"),
                CreateTypeValeur(35, "HCO3", typesAnalyse.First(x => x.Nom == "HCO3"), "22-28 mmol/L"),
                CreateTypeValeur(36, "pH", typesAnalyse.First(x => x.Nom == "pH" && x.Category == categories[2]), "7.35-7.45"),
                CreateTypeValeur(37, "pCO2", typesAnalyse.First(x => x.Nom == "pCO2"), "35-45 mmHg"),
                CreateTypeValeur(38, "pO2", typesAnalyse.First(x => x.Nom == "pO2"), "80-100 mmHg"),
                CreateTypeValeur(39, "Excès de base", typesAnalyse.First(x => x.Nom == "Excès de base"), "-2 à +2 mmol/L"),
                CreateTypeValeur(40, "Glucose", typesAnalyse.First(x => x.Nom == "Glucose" && x.Category == categories[2]), "Aci3.5-5"),
                CreateTypeValeur(41, "Triglycérides", typesAnalyse.First(x => x.Nom == "Triglycérides"), "<1.7 mmol/L"),
                CreateTypeValeur(42, "HDL-cholestérol", typesAnalyse.First(x => x.Nom == "HDL-cholestérol"), ">1.0 mmol/L"),
                CreateTypeValeur(43, "LDL-cholestérol", typesAnalyse.First(x => x.Nom == "LDL-cholestérol"), "<2.5 mmol/L"),
                CreateTypeValeur(44, "Cholestérol total", typesAnalyse.First(x => x.Nom == "Cholestérol total"), "<5.2 mmol/L"),
                CreateTypeValeur(45, "Protéines totales", typesAnalyse.First(x => x.Nom == "Protéines totales"), "60-80 g/L"),
                CreateTypeValeur(46, "Albumine", typesAnalyse.First(x => x.Nom == "Albumine"), "35-50 g/L"),
                CreateTypeValeur(47, "b-HCG qualitatif", typesAnalyse.First(x => x.Nom == "b-HCG qualitatif"), "Négatif"),
                CreateTypeValeur(48, "Drogues de rue", typesAnalyse.First(x => x.Nom == "Drogue de rue"), "Négatif"),
                CreateTypeValeur(49, "Éthanol", typesAnalyse.First(x => x.Nom == "Éthanol"), "0 mmol/L"),
                CreateTypeValeur(50, "Osmolarité urinaire", typesAnalyse.First(x => x.Nom == "Osmolarité urinaire"), "540 mosmol/kg"),
                CreateTypeValeur(51, "Osmolarité sérique", typesAnalyse.First(x => x.Nom == "Osmolarité sérique"), "290 mosmol/kg"),
                CreateTypeValeur(52, "Glucose", typesAnalyse.First(x => x.Nom == "Glucose" && x.Category == categories[3]), "Négatif"),
                CreateTypeValeur(53, "Corps cétoniques", typesAnalyse.First(x => x.Nom == "Corps cétoniques"), "Négatif"),
                CreateTypeValeur(54, "Densité", typesAnalyse.First(x => x.Nom == "Densité"), "1.005-1.030"),
                CreateTypeValeur(55, "Sang", typesAnalyse.First(x => x.Nom == "Sang"), "Négatif"),
                CreateTypeValeur(56, "pH", typesAnalyse.First(x => x.Nom == "pH"), "4-8"),
                CreateTypeValeur(57, "Protéines", typesAnalyse.First(x => x.Nom == "Protéines"), "Négatif"),
                CreateTypeValeur(58, "Leucocytes", typesAnalyse.First(x => x.Nom == "Leucocytes"), "Négatif"),
                CreateTypeValeur(59, "Nitrites", typesAnalyse.First(x => x.Nom == "Nitrites"), "Négatif"),
                CreateTypeValeur(60, "Bilirubine", typesAnalyse.First(x => x.Nom == "Bilirubine"), "Négatif"),
                CreateTypeValeur(61, "Urobilinogène", typesAnalyse.First(x => x.Nom == "Urobilinogène"), "Négatif"),
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
