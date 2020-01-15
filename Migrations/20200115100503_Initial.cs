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
                    Montant = table.Column<double>(nullable: false),
                    DateEmission = table.Column<DateTime>(nullable: false),
                    DateReglement = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Adresse", "Mail", "NoSiret", "NoTel", "Nom" },
                values: new object[] { new Guid("0b33db74-80a4-4ba3-b896-3d45dc7e9ed5"), "265 RUE PIERRE JEAN-BAPTISTE 59002 Lille", "societeproxiad@proxiad.fr", "A127EBHYULIDU1", "0322387458", "Proxiad" });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "Id", "DateEmission", "DateReglement", "Description", "IdClient", "Montant", "NoFacture" },
                values: new object[] { new Guid("bef4ed48-5080-407c-83aa-589648ed9d4e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Achat de deux esclaves chez IB Formation", new Guid("0b33db74-80a4-4ba3-b896-3d45dc7e9ed5"), 50000.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_IdClient",
                table: "Factures",
                column: "IdClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
