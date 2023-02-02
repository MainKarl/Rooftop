using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "TypeAnalyses",
                columns: table => new
                {
                    IdTypeAnalyse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequeteAnalyseIdRequete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAnalyses", x => x.IdTypeAnalyse);
                    table.ForeignKey(
                        name: "FK_TypeAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                        column: x => x.RequeteAnalyseIdRequete,
                        principalTable: "RequeteAnalyses",
                        principalColumn: "IdRequete");
                });

            migrationBuilder.CreateTable(
                name: "TypeValeurs",
                columns: table => new
                {
                    IdTypeValeur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAnalyseIdTypeAnalyse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeValeurs", x => x.IdTypeValeur);
                    table.ForeignKey(
                        name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseIdTypeAnalyse",
                        column: x => x.TypeAnalyseIdTypeAnalyse,
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
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "Nom", "RequeteAnalyseIdRequete" },
                values: new object[,]
                {
                    { 1, "Albumine", null },
                    { 2, "ALT", null },
                    { 3, "Bilan lipidique", null },
                    { 4, "Bilirubine totale", null },
                    { 5, "Calcium total", null },
                    { 6, "Cortisol", null },
                    { 7, "Cortisol post-dexaméthasone", null },
                    { 8, "Créatinine", null },
                    { 9, "Créatinine kinase", null },
                    { 10, "Électrolytes", null },
                    { 11, "Ferritine", null },
                    { 12, "Magnésium", null },
                    { 13, "Phosphatase alcaline", null },
                    { 14, "Phosphore", null },
                    { 15, "Protéine C réactive", null },
                    { 16, "Protéines totales", null },
                    { 17, "TSH et algorithme T4L et T3L", null }
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
                name: "IX_ResultatAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                column: "RequeteAnalyseIdRequete");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatAnalyses_TypeValeurIdTypeValeur",
                table: "ResultatAnalyses",
                column: "TypeValeurIdTypeValeur");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnalyses_RequeteAnalyseIdRequete",
                table: "TypeAnalyses",
                column: "RequeteAnalyseIdRequete");

            migrationBuilder.CreateIndex(
                name: "IX_TypeValeurs_TypeAnalyseIdTypeAnalyse",
                table: "TypeValeurs",
                column: "TypeAnalyseIdTypeAnalyse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultatAnalyses");

            migrationBuilder.DropTable(
                name: "TypeValeurs");

            migrationBuilder.DropTable(
                name: "TypeAnalyses");

            migrationBuilder.DropTable(
                name: "RequeteAnalyses");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Medecins");
        }
    }
}
