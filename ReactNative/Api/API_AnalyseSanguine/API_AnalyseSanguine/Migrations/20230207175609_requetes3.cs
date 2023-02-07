using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class requetes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RequeteAnalyses",
                columns: new[] { "IdRequete", "AnalyseDemande", "CodeAcces", "DateEchantillon", "DossierIdDossier", "MedecinIdMedecin", "NomTechnicien" },
                values: new object[,]
                {
                    { 1, "", new Guid("3b59dc03-483d-4042-8d0a-1069f47acb12"), new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Matheo Boudreau" },
                    { 2, "", new Guid("f352bcce-2180-4ba2-83b1-f16554b8cb10"), new DateTime(2017, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, "Jerome Frenette" },
                    { 3, "", new Guid("94629f47-ac04-440c-9569-4cd0c9e67543"), new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Clara Faubert" },
                    { 4, "", new Guid("2c859aaf-a17d-4785-baef-b4251cb9c1e7"), new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, "Louis Truchon" },
                    { 5, "", new Guid("72f47943-b843-410d-a2c8-7650e8a5fa34"), new DateTime(2006, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "Andreanne Pearson" },
                    { 6, "", new Guid("bc3368f6-9aa4-4d00-b910-a090472b0fa7"), new DateTime(2009, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, "Sabrina Beauvais" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6);
        }
    }
}
