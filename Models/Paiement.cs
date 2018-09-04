using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class Paiement
    {
        public int ID   { get; set; }
        public int MembreID   { get; set; }
        [Display(Name = "Montant payé *")]
        public Decimal MontantPayer   { get; set; }
        [Display(Name = "Date de paiement *")]
        public DateTime DatePayement   { get; set; }
        [Display(Name = "Moyen de paiement *")]
        public int MoyenPayement   { get; set; }
        [Display(Name = "ID Transaction *")]
        public string IDTransaction   { get; set; }
        [Display(Name = "Avance accordée *")]
        public Boolean AvanceAccord   { get; set; }
        [Display(Name = "Montant de l’avance * ")]
        public Decimal MontantAvance   { get; set; }
        [Display(Name = "ID du membre qui a avancé l’avance *")]
        public int? MembreAvanceID  { get; set; }

        [NotMapped]
        public string MembreReference { get; set; }

        public Membre Membre   { get; set; }
        public Membre MembreAvance { get; set; }
    }
}
