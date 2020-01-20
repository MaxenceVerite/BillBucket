using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class BillBucketContext : DbContext
    {

       public DbSet<Client> Clients { get; set; }

       public DbSet<Facture> Factures { get; set; }

       public DbSet<Prestation> Prestations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=BillBucketDB;Trusted_Connection=true");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(cli => cli.Id);

            modelBuilder.Entity<Facture>().HasKey(fac => fac.Id);

            modelBuilder.Entity<Prestation>().HasKey(pre => pre.Id);

           



            // Client <-> Facture
            modelBuilder.Entity<Client>().HasMany(cli => cli.Factures)
                                        .WithOne(fac => fac.Client)
                                        .HasForeignKey(fac=>fac.IdClient)
                                        .OnDelete(DeleteBehavior.Cascade);

            
            // Facture <-> Prestations 
            modelBuilder.Entity<Facture>().HasMany(fac => fac.Prestations)
                                          .WithOne(com => com.Facture)
                                          .HasForeignKey(com=>com.IdFacture)
                                          .OnDelete(DeleteBehavior.Cascade);

          
            


            var cl1 = new Client() { 
                NoSiret="A127EBHYULIDU1",
                Nom="Proxiad",
                Mail="societeproxiad@proxiad.fr",
                NoTel="0322387458",
                Adresse="265 RUE PIERRE JEAN-BAPTISTE 59002 Lille"
            };


            var fa1 = new Facture() {
                IdClient = cl1.Id,
                NoFacture = 1,
                DateEmission = new DateTime(2000),
                DateReglement = new DateTime(2007),
                Description = "Achat de deux esclaves chez IB Formation"
            };

            var pr1 = new Prestation()
            {
                IdFacture = fa1.Id,
                Nom = "Dressage de poulet",
                Description = "Nous dressons vos poulets d'entreprises. Ils ressortiront de chez nous en sachant abboyer, danser la polka et remplir vos fonctions de RH",
                Montant = 2700
            };

            var pr2 = new Prestation()
            {
                IdFacture = fa1.Id,
                Nom = "Location de chasseurs de prime",
                Description = "Nous vous fournissons l'élite des tireurs pour éliminer les forces de recrutement concurrentes. Pas cher du tout pour la qualité de la prestation",
                Montant = 50
            };


            modelBuilder.Entity<Client>().HasData(cl1);
            modelBuilder.Entity<Facture>().HasData(fa1);
            modelBuilder.Entity<Prestation>().HasData(pr1,pr2);




        }
    }


  
}
