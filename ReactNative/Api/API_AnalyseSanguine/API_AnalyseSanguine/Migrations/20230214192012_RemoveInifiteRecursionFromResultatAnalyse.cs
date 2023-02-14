using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class RemoveInifiteRecursionFromResultatAnalyse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultatAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses");

            migrationBuilder.AlterColumn<int>(
                name: "RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("e0d8c6cd-cc64-4594-b0dc-45d4284bc024"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("5d365a9c-1e72-4dfd-a691-4125cce0a5ad"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("0522cf90-17bc-432b-9dd1-7de721da1260"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("3a37f0fb-f10c-4bab-9122-4d708aa41887"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("df79179e-48f7-4562-ada1-1bd74f710d11"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("e2046f81-66da-41c3-9884-86349f0e787b"));

            migrationBuilder.AddForeignKey(
                name: "FK_ResultatAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                column: "RequeteAnalyseIdRequete",
                principalTable: "RequeteAnalyses",
                principalColumn: "IdRequete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultatAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses");

            migrationBuilder.AlterColumn<int>(
                name: "RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("2b0cc892-7507-42d6-95f1-e4a9fdf585f5"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("2d7a6f55-f6b2-4fc1-b2bb-76d42784c9b4"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("5d36da0c-5f00-4886-9fd2-cfb8de1f2625"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("ae251f0c-668a-4181-8a0f-fed3d0f55ce7"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("8a9af982-9ba0-4aa6-bc43-42cdf83fab6b"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("690753b2-da44-4ba1-b4ee-5fcb022b9551"));

            migrationBuilder.AddForeignKey(
                name: "FK_ResultatAnalyses_RequeteAnalyses_RequeteAnalyseIdRequete",
                table: "ResultatAnalyses",
                column: "RequeteAnalyseIdRequete",
                principalTable: "RequeteAnalyses",
                principalColumn: "IdRequete",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
