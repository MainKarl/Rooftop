using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class seedDossier1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Dossiers",
                columns: new[] { "IdDossier", "DateNaissance", "Nom", "Note", "Prenom", "Sexe" },
                values: new object[] { 1, new DateTime(2001, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turgeon", null, "Victor", (byte)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dossiers",
                keyColumn: "IdDossier",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
