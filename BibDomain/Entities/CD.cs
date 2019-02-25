using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
   public class CD:Document
    {
        public int NbreDePlage { get; set; }
        public TimeSpan Duree { get; set; }
    }
}
