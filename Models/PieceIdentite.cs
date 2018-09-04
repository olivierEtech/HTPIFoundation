using System;
using System.Collections.Generic;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HTPIFoundation.Models
{
    public class PieceIdentite
    {
        public int ID { get; set; }
        public int TypePieceIdentiteID   { get; set; }

        public int? AutreTypePieceIdentiteID { get; set; }

        [Required]
        [Display(Name = "Numéro de pièce d’identité *")]
        public string NumPieceIdentite   { get; set; }

        [Required]
        [Display(Name = "Pays de délivrance *")]
        public int? PaysDelivranceID   { get; set; }

        [Required]
        [Display(Name = "Date de délivrance *")]
        public DateTime DateDelivrance   { get; set; }

        [Required]
        [Display(Name = "Date d'expiration")]
        public DateTime DateExpiration   { get; set; }
        [Display(Name = "Charger la pièce d’identité *")]
        public int? UploadPieceIdentiteID   { get; set; }

        [Display(Name = "Type de justificatif de domicile")]
        public int? TypeJustDomicileID { get; set; }
        public int? AutreTypeJustDomicileID { get; set; }

        [Display(Name = "Charger le justificatif de domicile")]
        public int? UploadJustificatifDomicileID   { get; set; }
        [Display(Name = "Charger l'extrait d'acte de naissance")]
        public int? UploadActeDeNaissanceID   { get; set; }

        [NotMapped]
        public string DelivrancePays { get; set; }

        public TypePieceIdentite TypePieceIdentite { get; set; }
        public Pays PaysDelivrance { get; set; }
        public Upload UploadPieceIdentite { get; set; }
        public TypeJustificatifDomicile TypeJustDomicile { get; set; }
        public Upload UploadJustificatifDomicile { get; set; }
        public Upload UploadActeDeNaissance { get; set; }
        public AutreTypePiece AutreTypePieceIdentite { get; set; }
        public AutreTypePiece AutreTypeJustDomicile { get; set; }
    }
}
