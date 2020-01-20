using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillBucket.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NoSiret = table.Column<string>(maxLength: 14, nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    NoTel = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdClient = table.Column<Guid>(nullable: false),
                    NoFacture = table.Column<int>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    DateReglement = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdFacture = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Montant = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestations_Factures_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "NoSiret", "NoTel", "Nom" },
                values: new object[] { new Guid("c47638a4-4647-4128-a4bc-cfba3d9e9998"), "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille", "societeproxiad@proxiad.fr", "A127EBHYULIDU1", "0322387458", "Proxiad" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "NoFacture" },
                values: new object[] { new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Achat de deux esclaves chez IB Formation", new Guid("c47638a4-4647-4128-a4bc-cfba3d9e9998"), 1 });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("746667bd-097a-4ff1-8a3b-b5d43445453f"), "Nous dressons vos poulets d'entreprises. Ils ressortiront de chez nous en sachant abboyer, danser la polka et remplir vos fonctions de RH", new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"), 2700.0, "Dressage de poulet" });

            migrationBuilder.InsertData(
                table: "Prestations",
                columns: new[] { "Id", "Description", "IdFacture", "Montant", "Nom" },
                values: new object[] { new Guid("932cc920-e77e-4da8-989e-6ed0f900dfe2"), "Nous vous fournissons l'élite des tireurs pour éliminer les forces de recrutement concurrentes. Pas cher du tout pour la qualité de la prestation", new Guid("25ea78f2-54ad-4291-b302-2be6bc1ee824"), 50.0, "Location de chasseurs de prime" });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_IdClient",
                table: "Factures",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Prestations_IdFacture",
                table: "Prestations",
                column: "IdFacture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
