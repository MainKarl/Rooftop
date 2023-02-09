using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class ajoutListRequete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "TypeAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_TypeAnalyses_RequeteAnalyseIdRequete",
                table: "TypeAnalyses");

            migrationBuilder.DropColumn(
                name: "RequeteAnalyseIdRequete",
                table: "TypeAnalyses");

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

            migrationBuilder.CreateIndex(
                name: "IX_RequeteAnalyseTypeAnalyse_RequeteAnalysesIdRequete",
                table: "RequeteAnalyseTypeAnalyse",
                column: "RequeteAnalysesIdRequete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequeteAnalyseTypeAnalyse");

            migrationBuilder.AddColumn<int>(
                name: "RequeteAnalyseIdRequete",
                table: "TypeAnalyses",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TypeAnalyses_RequeteAnalyseIdRequete",
                table: "TypeAnalyses",
                column: "RequeteAnalyseIdRequete");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "TypeAnalyses",
                column: "RequeteAnalyseIdRequete",
                principalTable: "RequeteAnalyses",
                principalColumn: "IdRequete");
        }
    }
}
