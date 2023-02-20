using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class seedTypeValeurMicroUrinaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("5c29d346-02aa-414d-9ab6-9d3e9959a6fd"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("82c061d3-afbf-4246-bbb7-381a27640b8c"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("f6646404-a7b4-4e8a-a8d1-caca8722b03a"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("7d49f211-7dae-4fe0-9424-395f3fc1e9ef"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("5d567ab4-f8a8-45fc-97ba-556a97aadaab"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("658bed7e-d8a1-45d8-a734-583d310f23db"));

            migrationBuilder.InsertData(
                table: "TypeValeurs",
                columns: new[] { "IdTypeValeur", "Nom", "Reference", "TypeAnalyseId" },
                values: new object[] { 83, "Microscopie urinaire", "Négatif", 57 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeValeurs",
                keyColumn: "IdTypeValeur",
                keyValue: 83);

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("8d396a21-4ffa-43e8-b2f4-4725335abf0f"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("7fa20290-4a5c-40f7-bed5-5352d0774ad2"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("b819c47b-d6ae-4f52-9ca2-c03a691d7842"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("0a139cf0-8bd6-4372-bf20-b554f67c7222"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("42e6e021-1719-49d7-aea0-c5d00488e577"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("ab81b200-0931-45d6-b83a-db2cb2551f6b"));
        }
    }
}
