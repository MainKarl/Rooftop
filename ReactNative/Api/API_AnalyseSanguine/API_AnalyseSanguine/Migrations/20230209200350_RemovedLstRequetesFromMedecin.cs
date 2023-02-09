using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class RemovedLstRequetesFromMedecin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 1,
                column: "CodeAcces",
                value: new Guid("ab40a2c0-855e-4ca8-bfc8-170fbfe8bff9"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 2,
                column: "CodeAcces",
                value: new Guid("fef07ed8-7439-4e85-b47a-e8381f2a8de7"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 3,
                column: "CodeAcces",
                value: new Guid("ab76c71f-9e51-452a-9769-d841ad9c94df"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 4,
                column: "CodeAcces",
                value: new Guid("4fbec4fc-1737-4970-a237-b036845fbf6f"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 5,
                column: "CodeAcces",
                value: new Guid("95e111ff-f763-47ed-b5bc-1d0aab346c02"));

            migrationBuilder.UpdateData(
                table: "RequeteAnalyses",
                keyColumn: "IdRequete",
                keyValue: 6,
                column: "CodeAcces",
                value: new Guid("daf40df2-6fff-45b1-a643-774b9abebbaf"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
