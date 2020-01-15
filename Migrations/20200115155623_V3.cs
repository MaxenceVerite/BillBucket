using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("c1f21413-5ce7-430c-9c16-aed8a45efa05"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("81e1f237-d6ec-45c1-939e-f8a148990f7f"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("9a902d7b-76e2-4f3b-83c0-01436f918677"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("0f9be4f2-d5f5-409b-9280-5c3d98cbfdbe"));

            migrationBuilder.DropColumn(
                name: "Montant",
                table: "Factures");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "NoSiret", "NoTel", "Nom" },
                values: new object[] { new Guid("1d6f9c4b-ac89-4d30-9a57-459bb0d58c38"), "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille", "societeproxiad@proxiad.fr", "A127EBHYULIDU1", "0322387458", "Proxiad" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { new Guid("7541e59d-a5ea-4267-85f3-ec8db35f34cd"), "Nous dressons vos poulets d'entreprises. Ils ressortiront de chez nous en sachant abboyer, danser la polka et remplir vos fonctions de RH", "Dressage de poulet" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { new Guid("ee380eb7-1a71-43c5-b01d-e7a8950e2314"), "Nous vous fournissons l'élite des tireurs pour éliminer les forces de recrutement concurrentes. Pas cher du tout pour la qualité de la prestation", "Location de chasseurs de prime" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "NoFacture" },
                values: new object[] { new Guid("26313c30-9b39-4b51-889e-44658a0aa309"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Achat de deux esclaves chez IB Formation", new Guid("1d6f9c4b-ac89-4d30-9a57-459bb0d58c38"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("26313c30-9b39-4b51-889e-44658a0aa309"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("7541e59d-a5ea-4267-85f3-ec8db35f34cd"));

            migrationBuilder.DeleteData(
                table: "Prestations",
                keyColumn: "Id",
                keyValue: new Guid("ee380eb7-1a71-43c5-b01d-e7a8950e2314"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1d6f9c4b-ac89-4d30-9a57-459bb0d58c38"));

            migrationBuilder.AddColumn<double>(
                name: "Montant",
                table: "Factures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "NoSiret", "NoTel", "Nom" },
                values: new object[] { new Guid("0f9be4f2-d5f5-409b-9280-5c3d98cbfdbe"), "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille", "societeproxiad@proxiad.fr", "A127EBHYULIDU1", "0322387458", "Proxiad" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { new Guid("81e1f237-d6ec-45c1-939e-f8a148990f7f"), "Nous dressons vos poulets d'entreprises. Ils ressortiront de chez nous en sachant abboyer, danser la polka et remplir vos fonctions de RH", "Dressage de poulet" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { new Guid("9a902d7b-76e2-4f3b-83c0-01436f918677"), "Nous vous fournissons l'élite des tireurs pour éliminer les forces de recrutement concurrentes. Pas cher du tout pour la qualité de la prestation", "Location de chasseurs de prime" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "Montant", "NoFacture" },
                values: new object[] { new Guid("c1f21413-5ce7-430c-9c16-aed8a45efa05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Achat de deux esclaves chez IB Formation", new Guid("0f9be4f2-d5f5-409b-9280-5c3d98cbfdbe"), 50000.0, 1 });
        }
    }
}
