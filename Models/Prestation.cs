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

        [Required]
        public string Nom { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
