using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillBucket.Models
{
    public class Facture
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid IdClient { get; set; }

        [Required]
        [Display(Name= "Numéro de facture")]
        public int NoFacture { get; set; }

        [Required]
        [Display(Name = "Date d'émission")]
        public DateTime DateEmission { get; set; }

        [Display(Name = "Date de réglement")]
        private DateTime _DateReglement;

        public DateTime DateReglement
        {
            get { return _DateReglement; }
            set {
                
                if(DateEmission > value)
                {
                    throw new InvalidOperationException("La date de réglement ne peut pas survenir avant la date d'emission");
                }
                _DateReglement = value; }
        }

      
        [MinLength(5)]
        [MaxLength(1000)]

        public string Description { get; set; }


        public virtual ICollection<Prestation> Prestations{ get; set; }
        public virtual Client Client { get; set; }


    }
}
