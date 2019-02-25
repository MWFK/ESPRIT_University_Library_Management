using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
 public   class Bibliotheque
    {
        public int BibliothequeCode { get; set; }
        public int NbrDoc { get; set; }
        public ICollection<Document> Documents{ get; set; }
    }
}
