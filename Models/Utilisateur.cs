using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class Utilisateur
    {
        //private HTPIFoundationContext context;
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateCrt { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
