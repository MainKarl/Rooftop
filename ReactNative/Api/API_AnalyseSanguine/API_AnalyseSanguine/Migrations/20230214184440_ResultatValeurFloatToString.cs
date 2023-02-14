using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class ResultatValeurFloatToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Valeur",
                table: "ResultatAnalyses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("4b5bea76-58ba-48b3-89a3-66fd582e314a"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("720e7a4f-db39-4d33-8315-38b56d851131"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("672afc48-29e6-4f8e-9cf5-06d2a12cb525"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("5f952717-b349-4926-b35f-1c6d80ecf2d3"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("905c9ea1-c328-46c2-88a4-fa90ad5350fd"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("3774b1c2-a433-4b7d-b82b-8733b9b4633d"));

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 53,
                column: "Nom",
                value: "Éthanol");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 54,
                column: "Nom",
                value: "Osmolarité urinaire");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 55,
                column: "Nom",
                value: "Osmolarité sérique");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 56,
                column: "Nom",
                value: "Drogues de rue");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 57,
                column: "Nom",
                value: "Microscopie urinaire");

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 48,
                column: "TypeAnalyseId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 49,
                column: "TypeAnalyseId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 50,
                column: "TypeAnalyseId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 51,
                column: "TypeAnalyseId",
                value: 55);

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[,]
                {
                    { 62, "GB", "4.8-10.8 X 10⁹/L", 16 },
                    { 63, "GR", "♂ : 4.4-6.0 X 10¹²/L,♀ : 4.0-5.6 X 10¹²/L", 16 },
                    { 64, "Hb", "♂ : 134-170 g/L,♀ : 117-157 g/L", 16 },
                    { 65, "Ht", "♂ : 0.420-0.500 g/L,♀ : 0.370-0.470 L/L", 16 },
                    { 66, "VMC", "81-99 fL", 16 },
                    { 67, "TGMH", "27-33 pg", 16 },
                    { 68, "CGMH", "323-365 g/L", 16 },
                    { 69, "IDC", "12.7-16.0 %, 37.6-50.3 fL", 16 },
                    { 70, "Plt", "140-400 X 10⁹/L", 16 },
                    { 71, "VMP", "7.4-10.4 fL", 16 },
                    { 72, "IDP", "15-17 %", 16 },
                    { 73, "Plt", "140-400 X 10⁹/L", 17 },
                    { 74, "Micro", "♂ : 0.420-0.500 g/L,♀ : 0.370-0.470 L/L", 18 },
                    { 75, "VS", "♂ : 0-10 mm/h,♀ : 0.20 mm/h", 19 },
                    { 76, "NEUTRO", "50-70 %,2.2-6.5 X 10⁹/L", 20 },
                    { 77, "STAB", "0-80 %,0.05-0.10 X 10⁹/L", 20 },
                    { 78, "EOSINO", "0.01-4 %,0.02-0.440 X 10⁹/L", 20 },
                    { 79, "BASO", "0.01-2 %,0.00-0.15 X 10⁹/L", 20 },
                    { 80, "LYMPHO", "17-42 %,1.2-3.6 X 10⁹/L", 20 },
                    { 81, "MONO", "1-12 %,0.08-0.870 X 10⁹/L", 20 },
                    { 82, "LY.AT.", "0-5 %,< 1.0 X 10⁹/L", 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 82);

            migrationBuilder.AlterColumn<float>(
                name: "Valeur",
                table: "ResultatAnalyses",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("807f612b-79e2-4c55-9040-4690df4c1d5d"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("c53cb796-37fe-453b-a36f-cbf13a9afb25"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("c1c8ec8a-f41d-4176-936f-0e4554d1b787"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("ab003408-6932-44fa-98d7-475b15715636"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("3bb93ca3-2d8d-464c-a7ba-ae74a5df9f1f"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("1d7c8c45-6fe4-483a-bade-39444f06f603"));

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 53,
                column: "Nom",
                value: "Drogues de rue");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 54,
                column: "Nom",
                value: "Éthanol");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 55,
                column: "Nom",
                value: "Microscopie urinaire");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 56,
                column: "Nom",
                value: "Osmolarité urinaire");

            migrationBuilder.UpdateData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 57,
                column: "Nom",
                value: "Osmolarité sérique");

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 48,
                column: "TypeAnalyseId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 49,
                column: "TypeAnalyseId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 50,
                column: "TypeAnalyseId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 51,
                column: "TypeAnalyseId",
                value: 57);
        }
    }
}
