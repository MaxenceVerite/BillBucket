using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("bef4ed48-5080-407c-83aa-589648ed9d4e"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("0b33db74-80a4-4ba3-b896-3d45dc7e9ed5"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Factures",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdFacture = table.Column<Guid>(nullable: false),
                    IdPrestation = table.Column<Guid>(nullable: false),
                    Montant = table.Column<double>(nullable: false),
                    FactureId = table.Column<Guid>(nullable: true),
                    PrestationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commandes_Prestations_PrestationId",
                        column: x => x.PrestationId,
                        principalTable: "Prestations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_FactureId",
                table: "Commandes",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_PrestationId",
                table: "Commandes",
                column: "PrestationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DeleteData(
                table: "Factures",
                keyColumn: "Id",
                keyValue: new Guid("c1f21413-5ce7-430c-9c16-aed8a45efa05"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("0f9be4f2-d5f5-409b-9280-5c3d98cbfdbe"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Factures",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "NoSiret", "NoTel", "Nom" },
                values: new object[] { new Guid("0b33db74-80a4-4ba3-b896-3d45dc7e9ed5"), "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille", "societeproxiad@proxiad.fr", "A127EBHYULIDU1", "0322387458", "Proxiad" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "Montant", "NoFacture" },
                values: new object[] { new Guid("bef4ed48-5080-407c-83aa-589648ed9d4e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Achat de deux esclaves chez IB Formation", new Guid("0b33db74-80a4-4ba3-b896-3d45dc7e9ed5"), 50000.0, 1 });
        }
    }
}
