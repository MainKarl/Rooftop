using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class ajoutTypeValeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseIdTypeAnalyse",
                table: "TypeValeurs");

            migrationBuilder.RenameColumn(
                name: "TypeAnalyseIdTypeAnalyse",
                table: "TypeValeurs",
                newName: "TypeAnalyseId");

            migrationBuilder.RenameIndex(
                name: "IX_TypeValeurs_TypeAnalyseIdTypeAnalyse",
                table: "TypeValeurs",
                newName: "IX_TypeValeurs_TypeAnalyseId");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Analyse de biochimie" },
                    { 4, "Routine d'urine" }
                });

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("d53093a2-160d-457e-a94b-52f39122cb14"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("f33dc835-c487-4f04-af1a-ce0134c71e1b"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("8a565fa7-0906-40f6-b27f-73acbf861226"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("a6385ca3-68d9-47c9-9d22-861e38fc6a12"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("d13f3c91-8959-4cfd-b762-825669cf80f3"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("695e7d6d-2097-4b35-9612-600af492ad9e"));

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 18,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "Micro" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 19,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "VS" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 20,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "FSC diff." });

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
                    { 17, 2, "Plt" }
                });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[,]
                {
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
                    { 29, "Troponine", "< 0.4ug/L", 34 }
                });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[] { 30, "Protéine C-réactive", "< 10mg/L", 35 });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[] { 31, "BNP", "< 100pg/mL", 36 });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[] { 32, "Potassium", "3.5-5 mmol/L", 37 });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 21,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "ALP" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 22,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "ALT" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 23,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Amylase" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 24,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "AST" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 25,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "GGT" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 26,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Lipase" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 27,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Créatinine sérique" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 28,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Créatinine urinaire" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 29,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Acide urique" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 30,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Urée" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 31,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Clairance de la créatinine" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 32,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Bilirubine totale" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 33,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Bilirubine conjuguée" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 34,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Troponine" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 35,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Protéine C-réactive" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 36,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "BNP" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 37,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 3, "Potassium" });

            migrationBuilder.InsertData(
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "CategoryId", "Nom" },
                values: new object[,]
                {
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
                    { 62, 4, "pH" }
                });

            migrationBuilder.InsertData(
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "CategoryId", "Nom" },
                values: new object[,]
                {
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
                    { 15, "AP", "80-120 %", 15 }
                });

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[,]
                {
                    { 33, "Sodium", "135-145 mmol/L", 38 },
                    { 34, "Chlorure", "98-108 mmol/L", 39 },
                    { 35, "HCO3", "22-28 mmol/L", 40 },
                    { 36, "pH", "7.35-7.45", 41 },
                    { 37, "pCO2", "35-45 mmHg", 42 },
                    { 38, "pO2", "80-100 mmHg", 43 },
                    { 39, "Excès de bases", "-2 à +2 mmol/L", 44 },
                    { 40, "Glucose", "Aci3.5-5", 45 },
                    { 41, "Triglycérides", "<1.7 mmol/L", 46 },
                    { 42, "HDL-cholestérol", ">1.0 mmol/L", 47 },
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

            migrationBuilder.AddForeignKey(
                name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseId",
                table: "TypeValeurs",
                column: "TypeAnalyseId",
                principalTable: "TypeAnalyses",
                principalColumn: "IdTypeAnalyse",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseId",
                table: "TypeValeurs");

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "TypeAnalyseId",
                table: "TypeValeurs",
                newName: "TypeAnalyseIdTypeAnalyse");

            migrationBuilder.RenameIndex(
                name: "IX_TypeValeurs_TypeAnalyseId",
                table: "TypeValeurs",
                newName: "IX_TypeValeurs_TypeAnalyseIdTypeAnalyse");

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("0b601165-9117-406b-ad35-33ecbf0d93bd"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("dd0481f0-5d8b-474a-b1ce-c4890149c2e6"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("136006e3-f889-48ac-9908-a90bacd9aba6"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("ff47bc6a-efdd-4fda-88f1-3b7c90bd971c"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("816319f1-a364-4fbe-a161-1784bcfca0cc"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("1a2b9186-9318-4fb2-a651-1496cc367de5"));

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 18,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "TS" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 19,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "To" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 20,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "PTT" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 21,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "PT" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 22,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "TT" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 23,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "Fibrinogène" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 24,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "Facteur" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 25,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "D-dimères" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 26,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "fVW" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 27,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "LA Screen" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 28,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "Anti-Xa" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 29,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "Prt C" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 30,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "Prt S" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 31,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "PLG" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 32,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 1, "AP" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 33,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "FSC num." });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 34,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "Plt" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 35,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "Micro" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 36,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "VS" });

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 37,
                columns: new[] { "CategoryId", "Nom" },
                values: new object[] { 2, "FSC diff." });

            migrationBuilder.AddForeignKey(
                name: "FK_TypeValeurs_TypeAnalyses_TypeAnalyseIdTypeAnalyse",
                table: "TypeValeurs",
                column: "TypeAnalyseIdTypeAnalyse",
                principalTable: "TypeAnalyses",
                principalColumn: "IdTypeAnalyse",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
