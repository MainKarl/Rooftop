using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AnalyseSanguine.Migrations
{
    public partial class seedMedecin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medecins",
                columns: new[] { "IdMedecin", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "Banville", "Zacharie" },
                    { 2, "Bourque", "Yannick" },
                    { 3, "Langlais", "Jonathan" },
                    { 4, "Jetté", "Antony" },
                    { 5, "Denis", "Lucas" },
                    { 6, "Lagacé", "Mathilde" },
                    { 7, "Néron", "Alicia" },
                    { 8, "Godin", "Raphaelle" },
                    { 9, "Martinez", "Leonie" },
                    { 10, "Daneau", "Rose" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medecins",
                keyColumn: "IdMedecin",
                keyValue: 10);
        }
    }
}
