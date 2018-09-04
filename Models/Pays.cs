using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class Pays
    {
        public int ID { get; set; }
        public string code { get; set; }
        public string alpha2 { get; set; }
        public string alpha3 { get; set; }
        public string nom_en_gb { get; set; }
        public string nom_fr_fr { get; set; }
    }
}
