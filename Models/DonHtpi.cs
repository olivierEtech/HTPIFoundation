using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class DonHtpi
    {
        public int ID { get; set; }
        public int MembreID { get; set; }
        [Display(Name = " D’un montant de *")]
        public Decimal MontantTotal { get; set; }
        [Display(Name = " Détail *")]
        public string Detail { get; set; }
        [Display(Name = "Remboursement / retenue de l’avance: *")]
        public Decimal MontantAvance { get; set; }
        [Display(Name = "Retenue pour frais de transfert : * ")]
        public Decimal FraisTransfert { get; set; }
        [Display(Name = "Le don a été Payé Le : * ")]
        public DateTime DatePayement { get; set; }
        [Display(Name = "Par le Moyen de paiement *:")]
        public int MoyenPayement { get; set; }
        [Display(Name = "N° reçu papier *")]
        public string NumRecue { get; set; }
        [Display(Name = "N° transaction Mobile Money *")]
        public string IDTransaction { get; set; }

        public Membre Membre { get; set; }
    }
}
