using System;

namespace BillBucket.Models
{
    public class Commande
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdFacture { get; set; }
        public Guid IdPrestation { get; set; }
        public double Montant { get; set; }

        public virtual Facture Facture { get; set; }

        public virtual Prestation Prestation { get; set; }
    }
}