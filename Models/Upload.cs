using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace HTPIFoundation.Models
{
    public class Upload
    {
        public int ID { get; set; }
        public string Uri { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
    }
}
