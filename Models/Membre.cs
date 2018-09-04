using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class Membre
    {
        public int ID { get; set; }
        [Display(Name = "Appellation *")]
        public int Appellation   { get; set; }

        [Required]
        [Display(Name = "NOM *")]
        public string Nom   { get; set; }

        [Required]
        [Display(Name = "Prénom(s) *")]
        public string Prenom   { get; set; }

        [Required]
        [Display(Name = "Date de naissance *")]
        public DateTime DateNaissance   { get; set; }

        [Required]
        [Display(Name = "Nationalité *")]
        public string Nationnalite   { get; set; }

        [Required]
        [Display(Name = "Profession *")]
        public string Profession   { get; set; }

        [Display(Name = "Nom et numéro de rue ou toute indication utile")]
        public string Adresse   { get; set; }

        [Required]
        [Display(Name = "Code postal *")]
        public string CodePostal { get; set; }

        [Required]
        [Display(Name = "Ville et/ou Village de résidence *")]
        public string Ville   { get; set; }

        [Display(Name = "Pays*")]
        public int? PaysID   { get; set; }
        
        public int PieceIdentiteID { get; set; }

        [Display(Name = "Email")]
        public string Email   { get; set; }

        [Display(Name = "Numéro de téléphone fixe")]
        public string TelephoneFixe   { get; set; }

        [Display(Name = "N° de téléphone mobile")]
        public string TelephoneMobile   { get; set; }
        
        [Required]
        [Display(Name = "Numéro compatible Mobile Money ? *")]
        public int NumCompatibleMobileMoney   { get; set; }

        [Display(Name = "Opérateur")]
        public int OperateurID   { get; set; }

        [Display(Name = "L'ID de la personne qui vous a parlé de la Fondation HTPI")]
        public int? PersonneReferenceID { get; set; }

        [Required]
        [Display(Name = "En adhérent à la Fondation HTPI je m engage à respecter la Charte du membre *")]
        public int AccepteCharteMembre { get; set; }

        [Display(Name = "ID membre")]
        public string ID_HTPI { get;set; }

        [NotMapped]
        public string MembrePays { get;set; }

        [NotMapped]
        public string MembreReference { get;set; }


        public Pays Pays { get; set; }
        public PieceIdentite PieceIdentite  { get; set; }
        public Operateur Operateur { get; set; }
        public Membre PersonneReference { get; set; }
        
    }
}
