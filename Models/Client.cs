using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Client
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(maximumLength:14, MinimumLength = 14)]
        [Display(Name = "Numéro de SIRET")]
        public string NoSiret { get; set; }

        [Required]
        [MinLength(3)]
        public string Nom { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Display(Name = "Numéro de téléphone")]
        public string NoTel { get; set; }

        [Display(Name = "Adresse Mail")]
        public string Mail { get; set; }


        public virtual ICollection<Facture> Factures { get; set; }
    }
}
