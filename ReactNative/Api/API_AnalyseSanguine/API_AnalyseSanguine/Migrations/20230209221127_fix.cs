using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
               name: "RequeteAnalyseTypeAnalyse");

            migrationBuilder.DropTable(
                name: "ResultatAnalyses");

            migrationBuilder.DropTable(
                name: "RequeteAnalyses");

            migrationBuilder.DropTable(
                name: "TypeValeurs");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "TypeAnalyses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    IdDossier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.IdDossier);
                });

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    IdMedecin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.IdMedecin);
                });

            migrationBuilder.CreateTable(
                name: "TypeAnalyses",
                columns: table => new
                {
                    IdTypeAnalyse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAnalyses", x => x.IdTypeAnalyse);
                    table.ForeignKey(
                        name: "FK_TypeAnalyses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequeteAnalyses",
                columns: table => new
                {
                    IdRequete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeAcces = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEchantillon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnalyseDemande = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomTechnicien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DossierIdDossier = table.Column<int>(type: "int", nullable: false),
                    MedecinIdMedecin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequeteAnalyses", x => x.IdRequete);
                    table.ForeignKey(
                        name: "FK_RequeteAnalyses_Dossiers_DossierIdDossier",
                        column: x => x.DossierIdDossier,
                        principalTable: "Dossiers",
                        principalColumn: "IdDossier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequeteAnalyses_Medecins_MedecinIdMedecin",
                        column: x => x.MedecinIdMedecin,
                        principalTable: "Medecins",
                        principalColumn: "IdMedecin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeValeurs",
                columns: table => new
                {
                    IdTypeValeur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAnalyseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeValeurs", x => x.IdTypeValeur);
                    table.ForeignKey(
                        name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseId",
                        column: x => x.TypeAnalyseId,
                        principalTable: "TypeAnalyses",
                        principalColumn: "IdTypeAnalyse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequeteAnalyseTypeAnalyse",
                columns: table => new
                {
                    LstTypeAnalyseIdTypeAnalyse = table.Column<int>(type: "int", nullable: false),
                    RequeteAnalysesIdRequete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequeteAnalyseTypeAnalyse", x => new { x.LstTypeAnalyseIdTypeAnalyse, x.RequeteAnalysesIdRequete });
                    table.ForeignKey(
                        name: "FK_RequeteAnalyseTypeAnalyse_RequeteAnalyses_RequeteAnalysesIdRequete",
                        column: x => x.RequeteAnalysesIdRequete,
                        principalTable: "RequeteAnalyses",
                        principalColumn: "IdRequete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequeteAnalyseTypeAnalyse_TypeAnalyses_LstTypeAnalyseIdTypeAnalyse",
                        column: x => x.LstTypeAnalyseIdTypeAnalyse,
                        principalTable: "TypeAnalyses",
                        principalColumn: "IdTypeAnalyse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultatAnalyses",
                columns: table => new
                {
                    IdResultatAnalyse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<float>(type: "real", nullable: false),
                    RequeteAnalyseIdRequete = table.Column<int>(type: "int", nullable: false),
                    TypeValeurIdTypeValeur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatAnalyses", x => x.IdResultatAnalyse);
                    table.ForeignKey(
                        name: "FK_ResultatAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                        column: x => x.RequeteAnalyseIdRequete,
                        principalTable: "RequeteAnalyses",
                        principalColumn: "IdRequete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultatAnalyses_TypeValeurs_TypeValeurIdTypeValeur",
                        column: x => x.TypeValeurIdTypeValeur,
                        principalTable: "TypeValeurs",
                        principalColumn: "IdTypeValeur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hémostase" },
                    { 2, "Hématologie" },
                    { 3, "Analyse de biochimie" },
                    { 4, "Routine d'urine" }
                });

            migrationBuilder.InsertData(
                table: "Dossiers",
                columns: new[] { "IdDossier", "DateNaissance", "Nom", "Note", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turgeon", null, "Victor", (byte)0 },
                    { 2, new DateTime(2002, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belval", null, "Jean-Philippe", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Medecins",
                columns: new[] { "IdMedecin", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "Banville", "Zacharie" },
                    { 2, "Bourque", "Yannick" },
                    { 3, "Langlais", "Jonathan" },
                    { 4, "Jetté", "Antony" },
                    { 5, "Denis", "Lucas" },
                    { 6, "Lagacé", "Mathilde" },
                    { 7, "Néron", "Alicia" },
                    { 8, "Godin", "Raphaelle" },
                    { 9, "Martinez", "Leonie" },
                    { 10, "Daneau", "Rose" }
                });

            migrationBuilder.InsertData(
                table: "RequeteAnalyses",
                columns: new[] { "IdRequete", "AnalyseDemande", "CodeAcces", "DateEchantillon", "DossierIdDossier", "MedecinIdMedecin", "NomTechnicien" },
                values: new object[,]
                {
                    { 1, "", new Guid("807f612b-79e2-4c55-9040-4690df4c1d5d"), new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Matheo Boudreau" },
                    { 2, "", new Guid("c53cb796-37fe-453b-a36f-cbf13a9afb25"), new DateTime(2017, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, "Jerome Frenette" },
                    { 3, "", new Guid("c1c8ec8a-f41d-4176-936f-0e4554d1b787"), new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Clara Faubert" },
                    { 4, "", new Guid("ab003408-6932-44fa-98d7-475b15715636"), new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, "Louis Truchon" },
                    { 5, "", new Guid("3bb93ca3-2d8d-464c-a7ba-ae74a5df9f1f"), new DateTime(2006, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "Andreanne Pearson" },
                    { 6, "", new Guid("1d7c8c45-6fe4-483a-bade-39444f06f603"), new DateTime(2009, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, "Sabrina Beauvais" }
                });

            migrationBuilder.InsertData(
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "CategoryId", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "TS" },
                    { 2, 1, "To" },
                    { 3, 1, "PTT" },
                    { 4, 1, "PT" },
                    { 5, 1, "TT" },
                    { 6, 1, "Fibrinogène" },
                    { 7, 1, "Facteur" },
                    { 8, 1, "D-dimères" },
                    { 9, 1, "fVW" },
                    { 10, 1, "LA Screen" },
                    { 11, 1, "Anti-Xa" },
                    { 12, 1, "Prt C" },
                    { 13, 1, "Prt S" },
                    { 14, 1, "PLG" },
                    { 15, 1, "AP" },
                    { 16, 2, "FSC num." },
                    { 17, 2, "Plt" },
                    { 18, 2, "Micro" },
                    { 19, 2, "VS" },
                    { 20, 2, "FSC diff." },
                    { 21, 3, "ALP" },
                    { 22, 3, "ALT" },
                    { 23, 3, "Amylase" },
                    { 24, 3, "AST" },
                    { 25, 3, "GGT" },
                    { 26, 3, "Lipase" },
                    { 27, 3, "Créatinine sérique" },
                    { 28, 3, "Créatinine urinaire" },
                    { 29, 3, "Acide urique" },
                    { 30, 3, "Urée" },
                    { 31, 3, "Clairance de la créatinine" },
                    { 32, 3, "Bilirubine totale" },
                    { 33, 3, "Bilirubine conjuguée" },
                    { 34, 3, "Troponine" },
                    { 35, 3, "Protéine C-réactive" },
                    { 36, 3, "BNP" }
                });

            migrationBuilder.InsertData(
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "CategoryId", "Nom" },
                values: new object[,]
                {
                    { 37, 3, "Potassium" },
                    { 38, 3, "Sodium" },
                    { 39, 3, "Chlorure" },
                    { 40, 3, "HCO3" },
                    { 41, 3, "pH" },
                    { 42, 3, "pCO2" },
                    { 43, 3, "pO2" },
                    { 44, 3, "Excès de bases" },
                    { 45, 3, "Glucose" },
                    { 46, 3, "Triglycérides" },
                    { 47, 3, "HDL-cholestérol" },
                    { 48, 3, "LDL-cholestérol" },
                    { 49, 3, "Cholestérol total" },
                    { 50, 3, "Protéines totales" },
                    { 51, 3, "Albumine" },
                    { 52, 3, "b-HCG qualitatif" },
                    { 53, 3, "Drogues de rue" },
                    { 54, 3, "Éthanol" },
                    { 55, 3, "Microscopie urinaire" },
                    { 56, 3, "Osmolarité urinaire" },
                    { 57, 3, "Osmolarité sérique" },
                    { 58, 4, "Glucose" },
                    { 59, 4, "Corps cétoniques" },
                    { 60, 4, "Densité" },
                    { 61, 4, "Sang" },
                    { 62, 4, "pH" },
                    { 63, 4, "Protéines" },
                    { 64, 4, "Leucocytes" },
                    { 65, 4, "Nitrites" },
                    { 66, 4, "Bilirubine" },
                    { 67, 4, "Urobilinogène" }
                });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[,]
                {
                    { 1, "TS", "4-8 min", 1 },
                    { 2, "To", "EPI: 80-150 secs,ADP: 60-100 secs", 2 },
                    { 3, "PTT", "22.0-40.0 secs", 3 },
                    { 4, "PT", "11.0-14.0 secs", 4 },
                    { 5, "TT", "≤ 24.0 secs", 5 },
                    { 6, "Fibrinogène", "2.0-4.0 g/L", 6 },
                    { 7, "Facteur", "50-150 %", 7 },
                    { 8, "D-dimères", "<0.50 µg/mL", 8 },
                    { 9, "fVW", "50-160 %", 9 },
                    { 10, "LA Screen", "≥1.20", 10 },
                    { 11, "Anti-Xa", "0.50-1.00 Ul-mL", 11 },
                    { 12, "Prt C", "70-130 %", 12 },
                    { 13, "Prt S", "70-130 %", 13 },
                    { 14, "PLG", "80-120 %", 14 },
                    { 15, "AP", "80-120 %", 15 },
                    { 16, "ALP", "<100 U/L *selon l'âge du patient", 21 },
                    { 17, "ALT", "0-37 U/L", 22 },
                    { 18, "Amylase", "<130 U/L", 23 },
                    { 19, "AST", "5-34 U/L", 24 },
                    { 20, "GGT", "<40 U/L", 25 },
                    { 21, "Lipase", "<200 U/L", 26 },
                    { 22, "Créatinine sérique", "57-92 umol/L", 27 },
                    { 23, "Créatinine urinaire", "9-18 mmol/24h", 28 },
                    { 24, "Acide urique", "210-460 umol/L", 29 },
                    { 25, "Urée", "2.5-6.4 mmol/L", 30 },
                    { 26, "Clairance de la créatinine", "1-3 mL/s", 31 },
                    { 27, "Bilirubine totale", "3.4 - 22 umol/L", 32 },
                    { 28, "Bilirubine conjuguée", "1.7 - 5 umol/L", 33 },
                    { 29, "Troponine", "< 0.4ug/L", 34 },
                    { 30, "Protéine C-réactive", "< 10mg/L", 35 },
                    { 31, "BNP", "< 100pg/mL", 36 },
                    { 32, "Potassium", "3.5-5 mmol/L", 37 },
                    { 33, "Sodium", "135-145 mmol/L", 38 },
                    { 34, "Chlorure", "98-108 mmol/L", 39 },
                    { 35, "HCO3", "22-28 mmol/L", 40 },
                    { 36, "pH", "7.35-7.45", 41 },
                    { 37, "pCO2", "35-45 mmHg", 42 },
                    { 38, "pO2", "80-100 mmHg", 43 },
                    { 39, "Excès de bases", "-2 à +2 mmol/L", 44 },
                    { 40, "Glucose", "Aci3.5-5", 45 },
                    { 41, "Triglycérides", "<1.7 mmol/L", 46 },
                    { 42, "HDL-cholestérol", ">1.0 mmol/L", 47 }
                });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[,]
                {
                    { 43, "LDL-cholestérol", "<2.5 mmol/L", 48 },
                    { 44, "Cholestérol total", "<5.2 mmol/L", 49 },
                    { 45, "Protéines totales", "60-80 g/L", 50 },
                    { 46, "Albumine", "35-50 g/L", 51 },
                    { 47, "b-HCG qualitatif", "Négatif", 52 },
                    { 48, "Drogues de rue", "Négatif", 53 },
                    { 49, "Éthanol", "0 mmol/L", 54 },
                    { 50, "Osmolarité urinaire", "540 mosmol/kg", 56 },
                    { 51, "Osmolarité sérique", "290 mosmol/kg", 57 },
                    { 52, "Glucose", "Négatif", 58 },
                    { 53, "Corps cétoniques", "Négatif", 59 },
                    { 54, "Densité", "1.005-1.030", 60 },
                    { 55, "Sang", "Négatif", 61 },
                    { 56, "pH", "4-8", 62 },
                    { 57, "Protéines", "Négatif", 63 },
                    { 58, "Leucocytes", "Négatif", 64 },
                    { 59, "Nitrites", "Négatif", 65 },
                    { 60, "Bilirubine", "Négatif", 66 },
                    { 61, "Urobilinogène", "Négatif", 67 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequeteAnalyses_DossierIdDossier",
                table: "RequeteAnalyses",
                column: "DossierIdDossier");

            migrationBuilder.CreateIndex(
                name: "IX_RequeteAnalyses_MedecinIdMedecin",
                table: "RequeteAnalyses",
                column: "MedecinIdMedecin");

            migrationBuilder.CreateIndex(
                name: "IX_RequeteAnalyseTypeAnalyse_RequeteAnalysesIdRequete",
                table: "RequeteAnalyseTypeAnalyse",
                column: "RequeteAnalysesIdRequete");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                column: "RequeteAnalyseIdRequete");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatAnalyses_TypeValeurIdTypeValeur",
                table: "ResultatAnalyses",
                column: "TypeValeurIdTypeValeur");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnalyses_CategoryId",
                table: "TypeAnalyses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeValeurs_TypeAnalyseId",
                table: "TypeValeurs",
                column: "TypeAnalyseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequeteAnalyseTypeAnalyse");

            migrationBuilder.DropTable(
                name: "ResultatAnalyses");

            migrationBuilder.DropTable(
                name: "RequeteAnalyses");

            migrationBuilder.DropTable(
                name: "TypeValeurs");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "TypeAnalyses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
