using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class ajoutCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 17);

            migrationBuilder.RenameColumn(
                name: "Unite",
                table: "TypeValeurs",
                newName: "Reference");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TypeAnalyses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hémostase" },
                    { 2, "Hématologie" }
                });

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("681f44be-987d-4028-bc4a-cfc07f9b5687"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("52e81e80-c996-4ac4-b14c-23c3aace0f3c"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("6ba9744e-9d1a-4e13-b077-a97f1403bd1a"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("2b0bdad8-7b51-4739-90f2-154a7d845ac0"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("4b859e3e-c626-4bde-a542-ffd2062fc94d"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("71ae4013-3adc-449b-9b9e-e2bce2002287"));

            migrationBuilder.InsertData(
                table: "TypeAnalyses",
                columns: new[] { "IdTypeAnalyse", "CategoryId", "Nom", "RequeteAnalyseIdRequete" },
                values: new object[,]
                {
                    { 18, 1, "TS", null },
                    { 19, 1, "To", null },
                    { 20, 1, "PTT", null },
                    { 21, 1, "PT", null },
                    { 22, 1, "TT", null },
                    { 23, 1, "Fibrinogène", null },
                    { 24, 1, "Facteur", null },
                    { 25, 1, "D-dimères", null },
                    { 26, 1, "fVW", null },
                    { 27, 1, "LA Screen", null },
                    { 28, 1, "Anti-Xa", null },
                    { 29, 1, "Prt C", null },
                    { 30, 1, "Prt S", null },
                    { 31, 1, "PLG", null },
                    { 32, 1, "AP", null },
                    { 33, 2, "FSC num.", null },
                    { 34, 2, "Plt", null },
                    { 35, 2, "Micro", null },
                    { 36, 2, "VS", null },
                    { 37, 2, "FSC diff.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnalyses_CategoryId",
                table: "TypeAnalyses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAnalyses_Category_CategoryId",
                table: "TypeAnalyses",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAnalyses_Category_CategoryId",
                table: "TypeAnalyses");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_TypeAnalyses_CategoryId",
                table: "TypeAnalyses");

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TypeAnalyses",
                keyColumn: "IdTypeAnalyse",
                keyValue: 37);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TypeAnalyses");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "TypeValeurs",
                newName: "Unite");

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("3b59dc03-483d-4042-8d0a-1069f47acb12"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("f352bcce-2180-4ba2-83b1-f16554b8cb10"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("94629f47-ac04-440c-9569-4cd0c9e67543"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("2c859aaf-a17d-4785-baef-b4251cb9c1e7"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("72f47943-b843-410d-a2c8-7650e8a5fa34"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("bc3368f6-9aa4-4d00-b910-a090472b0fa7"));

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
        }
    }
}
