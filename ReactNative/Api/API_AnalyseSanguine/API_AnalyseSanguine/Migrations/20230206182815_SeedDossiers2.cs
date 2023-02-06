using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class SeedDossiers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dossiers",
                columns: new[] { "IdDossier", "DateNaissance", "Nom", "Note", "Prenom", "Sexe" },
                values: new object[] { 2, new DateTime(2002, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belval", null, "Jean-Philippe", (byte)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dossiers",
                keyColumn: "IdDossier",
                keyValue: 2);
        }
    }
}
