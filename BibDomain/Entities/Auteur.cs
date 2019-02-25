using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{

   public class Auteur
    {
        public int AuteurCode { get; set; }
        public NomComplet nomComplet { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
