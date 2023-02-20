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
                TypeAnalyseId = typeAnalyse.IdTypeAnalyse,
                Reference=reference,
            };
        }

        private static void SeedTypesValeur(this ModelBuilder builder, IEnumerable<TypeValeur> typeValeurs)
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
                CreateTypeAnalyse(1, "TS", categories[0]),
                CreateTypeAnalyse(2, "To", categories[0]),
                CreateTypeAnalyse(3, "PTT", categories[0]),
                CreateTypeAnalyse(4, "PT", categories[0]),
                CreateTypeAnalyse(5, "TT", categories[0]),
                CreateTypeAnalyse(6, "Fibrinogène", categories[0]),
                CreateTypeAnalyse(7, "Facteur", categories[0]),
                CreateTypeAnalyse(8, "D-dimères", categories[0]),
                CreateTypeAnalyse(9, "fVW", categories[0]),
                CreateTypeAnalyse(10, "LA Screen", categories[0]),
                CreateTypeAnalyse(11, "Anti-Xa", categories[0]),
                CreateTypeAnalyse(12, "Prt C", categories[0]),
                CreateTypeAnalyse(13, "Prt S", categories[0]),
                CreateTypeAnalyse(14, "PLG", categories[0]),
                CreateTypeAnalyse(15, "AP", categories[0]),

                //Hématologie
                CreateTypeAnalyse(16, "FSC num.", categories[1]),
                CreateTypeAnalyse(17, "Plt", categories[1]),
                CreateTypeAnalyse(18, "Micro", categories[1]),
                CreateTypeAnalyse(19, "VS", categories[1]),
                CreateTypeAnalyse(20, "FSC diff.", categories[1]),

                // Analyse de biochimie
                CreateTypeAnalyse(21, "ALP", categories[2]),
                CreateTypeAnalyse(22, "ALT", categories[2]),
                CreateTypeAnalyse(23, "Amylase", categories[2]),
                CreateTypeAnalyse(24, "AST", categories[2]),
                CreateTypeAnalyse(25, "GGT", categories[2]),
                CreateTypeAnalyse(26, "Lipase", categories[2]),
                CreateTypeAnalyse(27, "Créatinine sérique", categories[2]),
                CreateTypeAnalyse(28, "Créatinine urinaire", categories[2]),
                CreateTypeAnalyse(29, "Acide urique", categories[2]),
                CreateTypeAnalyse(30, "Urée", categories[2]),
                CreateTypeAnalyse(31, "Clairance de la créatinine", categories[2]),
                CreateTypeAnalyse(32, "Bilirubine totale", categories[2]),
                CreateTypeAnalyse(33, "Bilirubine conjuguée", categories[2]),
                CreateTypeAnalyse(34, "Troponine", categories[2]),
                CreateTypeAnalyse(35, "Protéine C-réactive", categories[2]),
                CreateTypeAnalyse(36, "BNP", categories[2]),
                CreateTypeAnalyse(37, "Potassium", categories[2]),
                CreateTypeAnalyse(38, "Sodium", categories[2]),
                CreateTypeAnalyse(39, "Chlorure", categories[2]),
                CreateTypeAnalyse(40, "HCO3", categories[2]),
                CreateTypeAnalyse(41, "pH", categories[2]),
                CreateTypeAnalyse(42, "pCO2", categories[2]),
                CreateTypeAnalyse(43, "pO2", categories[2]),
                CreateTypeAnalyse(44, "Excès de bases", categories[2]),
                CreateTypeAnalyse(45, "Glucose", categories[2]),
                CreateTypeAnalyse(46, "Triglycérides", categories[2]),
                CreateTypeAnalyse(47, "HDL-cholestérol", categories[2]),
                CreateTypeAnalyse(48, "LDL-cholestérol", categories[2]),
                CreateTypeAnalyse(49, "Cholestérol total", categories[2]),
                CreateTypeAnalyse(50, "Protéines totales", categories[2]),
                CreateTypeAnalyse(51, "Albumine", categories[2]),
                CreateTypeAnalyse(52, "b-HCG qualitatif", categories[2]),
                CreateTypeAnalyse(53, "Éthanol", categories[2]),
                CreateTypeAnalyse(54, "Osmolarité urinaire", categories[2]),
                CreateTypeAnalyse(55, "Osmolarité sérique", categories[2]),
                CreateTypeAnalyse(56, "Drogues de rue", categories[2]),
                CreateTypeAnalyse(57, "Microscopie urinaire", categories[2]),

                // Routine urinaire
                CreateTypeAnalyse(58, "Glucose", categories[3]),
                CreateTypeAnalyse(59, "Corps cétoniques", categories[3]),
                CreateTypeAnalyse(60, "Densité", categories[3]),
                CreateTypeAnalyse(61, "Sang", categories[3]),
                CreateTypeAnalyse(62, "pH", categories[3]),
                CreateTypeAnalyse(63, "Protéines", categories[3]),
                CreateTypeAnalyse(64, "Leucocytes", categories[3]),
                CreateTypeAnalyse(65, "Nitrites", categories[3]),
                CreateTypeAnalyse(66, "Bilirubine", categories[3]),
                CreateTypeAnalyse(67, "Urobilinogène", categories[3]),
            };

            SeedTypesAnalyse(builder, typesAnalyse);
            #endregion

            #region TypeValeur
            List<TypeValeur> typeValeurs = new List<TypeValeur> {
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
                CreateTypeValeur(62, "GB", typesAnalyse.First(x=>x.Nom == "FSC num."), "4.8-10.8 X 10⁹/L"),
                CreateTypeValeur(63, "GR", typesAnalyse.First(x=>x.Nom == "FSC num."), "♂ : 4.4-6.0 X 10¹²/L,♀ : 4.0-5.6 X 10¹²/L"),
                CreateTypeValeur(64, "Hb", typesAnalyse.First(x=>x.Nom == "FSC num."), "♂ : 134-170 g/L,♀ : 117-157 g/L"),
                CreateTypeValeur(65, "Ht", typesAnalyse.First(x=>x.Nom == "FSC num."), "♂ : 0.420-0.500 g/L,♀ : 0.370-0.470 L/L"),
                CreateTypeValeur(66, "VMC", typesAnalyse.First(x=>x.Nom == "FSC num."), "81-99 fL"),
                CreateTypeValeur(67, "TGMH", typesAnalyse.First(x=>x.Nom == "FSC num."), "27-33 pg"),
                CreateTypeValeur(68, "CGMH", typesAnalyse.First(x=>x.Nom == "FSC num."), "323-365 g/L"),
                CreateTypeValeur(69, "IDC", typesAnalyse.First(x=>x.Nom == "FSC num."), "12.7-16.0 %, 37.6-50.3 fL"),
                CreateTypeValeur(70, "Plt", typesAnalyse.First(x=>x.Nom == "FSC num."), "140-400 X 10⁹/L"),
                CreateTypeValeur(71, "VMP", typesAnalyse.First(x=>x.Nom == "FSC num."), "7.4-10.4 fL"),
                CreateTypeValeur(72, "IDP", typesAnalyse.First(x=>x.Nom == "FSC num."), "15-17 %"),

                CreateTypeValeur(73, "Plt", typesAnalyse.First(x=>x.Nom == "Plt"), "140-400 X 10⁹/L"),
                CreateTypeValeur(74, "Micro", typesAnalyse.First(x=>x.Nom == "Micro"), "♂ : 0.420-0.500 g/L,♀ : 0.370-0.470 L/L"),
                CreateTypeValeur(75, "VS", typesAnalyse.First(x=>x.Nom == "VS"), "♂ : 0-10 mm/h,♀ : 0.20 mm/h"),

                CreateTypeValeur(76, "NEUTRO", typesAnalyse.First(x=>x.Nom == "FSC diff."), "50-70 %,2.2-6.5 X 10⁹/L"),
                CreateTypeValeur(77, "STAB", typesAnalyse.First(x=>x.Nom == "FSC diff."), "0-80 %,0.05-0.10 X 10⁹/L"),
                CreateTypeValeur(78, "EOSINO", typesAnalyse.First(x=>x.Nom == "FSC diff."), "0.01-4 %,0.02-0.440 X 10⁹/L"),
                CreateTypeValeur(79, "BASO", typesAnalyse.First(x=>x.Nom == "FSC diff."), "0.01-2 %,0.00-0.15 X 10⁹/L"),
                CreateTypeValeur(80, "LYMPHO", typesAnalyse.First(x=>x.Nom == "FSC diff."), "17-42 %,1.2-3.6 X 10⁹/L"),
                CreateTypeValeur(81, "MONO", typesAnalyse.First(x=>x.Nom == "FSC diff."), "1-12 %,0.08-0.870 X 10⁹/L"),
                CreateTypeValeur(82, "LY.AT.", typesAnalyse.First(x=>x.Nom == "FSC diff."), "0-5 %,< 1.0 X 10⁹/L"),



                // Analyse de biochimie
                CreateTypeValeur(16, "ALP", typesAnalyse.First(x => x.Nom == "ALP"), "<100 U/L *selon l'âge du patient"),
                CreateTypeValeur(17, "ALT", typesAnalyse.First(x => x.Nom == "ALT"), "0-37 U/L"),
                CreateTypeValeur(18, "Amylase", typesAnalyse.First(x => x.Nom == "Amylase"), "<130 U/L"),
                CreateTypeValeur(19, "AST", typesAnalyse.First(x => x.Nom == "AST"), "5-34 U/L"),
                CreateTypeValeur(20, "GGT", typesAnalyse.First(x => x.Nom == "GGT"), "<40 U/L"),
                CreateTypeValeur(21, "Lipase", typesAnalyse.First(x => x.Nom == "Lipase"), "<200 U/L"),
                CreateTypeValeur(22, "Créatinine sérique", typesAnalyse.First(x => x.Nom == "Créatinine sérique"), "57-92 umol/L"),
                CreateTypeValeur(23, "Créatinine urinaire", typesAnalyse.First(x => x.Nom == "Créatinine urinaire"), "9-18 mmol/24h"),
                CreateTypeValeur(24, "Acide urique", typesAnalyse.First(x => x.Nom == "Acide urique"), "210-460 umol/L"),
                CreateTypeValeur(25, "Urée", typesAnalyse.First(x => x.Nom == "Urée"), "2.5-6.4 mmol/L"),
                CreateTypeValeur(26, "Clairance de la créatinine", typesAnalyse.First(x => x.Nom == "Clairance de la créatinine"), "1-3 mL/s"),
                CreateTypeValeur(27, "Bilirubine totale", typesAnalyse.First(x => x.Nom == "Bilirubine totale"), "3.4 - 22 umol/L"),
                CreateTypeValeur(28, "Bilirubine conjuguée", typesAnalyse.First(x => x.Nom == "Bilirubine conjuguée"), "1.7 - 5 umol/L"),
                CreateTypeValeur(29, "Troponine", typesAnalyse.First(x => x.Nom == "Troponine"), "< 0.4ug/L"),
                CreateTypeValeur(30, "Protéine C-réactive", typesAnalyse.First(x => x.Nom == "Protéine C-réactive"), "< 10mg/L"),
                CreateTypeValeur(31, "BNP", typesAnalyse.First(x => x.Nom == "BNP"), "< 100pg/mL"),
                CreateTypeValeur(32, "Potassium", typesAnalyse.First(x => x.Nom == "Potassium"), "3.5-5 mmol/L"),
                CreateTypeValeur(33, "Sodium", typesAnalyse.First(x => x.Nom == "Sodium"), "135-145 mmol/L"),
                CreateTypeValeur(34, "Chlorure", typesAnalyse.First(x => x.Nom == "Chlorure"), "98-108 mmol/L"),
                CreateTypeValeur(35, "HCO3", typesAnalyse.First(x => x.Nom == "HCO3"), "22-28 mmol/L"),
                CreateTypeValeur(36, "pH", typesAnalyse.First(x => x.IdTypeAnalyse == 41), "7.35-7.45"),
                CreateTypeValeur(37, "pCO2", typesAnalyse.First(x => x.Nom == "pCO2"), "35-45 mmHg"),
                CreateTypeValeur(38, "pO2", typesAnalyse.First(x => x.Nom == "pO2"), "80-100 mmHg"),
                CreateTypeValeur(39, "Excès de bases", typesAnalyse.First(x => x.Nom == "Excès de bases"), "-2 à +2 mmol/L"),
                CreateTypeValeur(40, "Glucose", typesAnalyse.First(x => x.IdTypeAnalyse == 45), "Aci3.5-5"),
                CreateTypeValeur(41, "Triglycérides", typesAnalyse.First(x => x.Nom == "Triglycérides"), "<1.7 mmol/L"),
                CreateTypeValeur(42, "HDL-cholestérol", typesAnalyse.First(x => x.Nom == "HDL-cholestérol"), ">1.0 mmol/L"),
                CreateTypeValeur(43, "LDL-cholestérol", typesAnalyse.First(x => x.Nom == "LDL-cholestérol"), "<2.5 mmol/L"),
                CreateTypeValeur(44, "Cholestérol total", typesAnalyse.First(x => x.Nom == "Cholestérol total"), "<5.2 mmol/L"),
                CreateTypeValeur(45, "Protéines totales", typesAnalyse.First(x => x.Nom == "Protéines totales"), "60-80 g/L"),
                CreateTypeValeur(46, "Albumine", typesAnalyse.First(x => x.Nom == "Albumine"), "35-50 g/L"),
                CreateTypeValeur(47, "b-HCG qualitatif", typesAnalyse.First(x => x.Nom == "b-HCG qualitatif"), "Négatif"),
                CreateTypeValeur(48, "Drogues de rue", typesAnalyse.First(x => x.Nom == "Drogues de rue"), "Négatif"),
                CreateTypeValeur(49, "Éthanol", typesAnalyse.First(x => x.Nom == "Éthanol"), "0 mmol/L"),
                CreateTypeValeur(50, "Osmolarité urinaire", typesAnalyse.First(x => x.Nom == "Osmolarité urinaire"), "540 mosmol/kg"),
                CreateTypeValeur(51, "Osmolarité sérique", typesAnalyse.First(x => x.Nom == "Osmolarité sérique"), "290 mosmol/kg"),
                
                // Routine d'urine
                CreateTypeValeur(52, "Glucose", typesAnalyse.First(x => x.IdTypeAnalyse == 58), "Négatif"),
                CreateTypeValeur(53, "Corps cétoniques", typesAnalyse.First(x => x.Nom == "Corps cétoniques"), "Négatif"),
                CreateTypeValeur(54, "Densité", typesAnalyse.First(x => x.Nom == "Densité"), "1.005-1.030"),
                CreateTypeValeur(55, "Sang", typesAnalyse.First(x => x.Nom == "Sang"), "Négatif"),
                CreateTypeValeur(56, "pH", typesAnalyse.First(x => x.IdTypeAnalyse == 62), "4-8"),
                CreateTypeValeur(57, "Protéines", typesAnalyse.First(x => x.Nom == "Protéines"), "Négatif"),
                CreateTypeValeur(58, "Leucocytes", typesAnalyse.First(x => x.Nom == "Leucocytes"), "Négatif"),
                CreateTypeValeur(59, "Nitrites", typesAnalyse.First(x => x.Nom == "Nitrites"), "Négatif"),
                CreateTypeValeur(60, "Bilirubine", typesAnalyse.First(x => x.Nom == "Bilirubine"), "Négatif"),
                CreateTypeValeur(61, "Urobilinogène", typesAnalyse.First(x => x.Nom == "Urobilinogène"), "Négatif"),
                CreateTypeValeur(83, "Microscopie urinaire", typesAnalyse.First(x=>x.Nom == "Microscopie urinaire"),"Négatif"),
            };

            SeedTypesValeur(builder, typeValeurs);
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
