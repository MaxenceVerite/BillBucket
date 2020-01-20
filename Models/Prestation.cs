using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Prestation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IdFacture { get; set; }

        [Required]
        public string Nom { get; set; }

        public double Montant { get; set; }
        public string Description { get; set; }
        public virtual Facture Facture { get; set; }
    }
}
