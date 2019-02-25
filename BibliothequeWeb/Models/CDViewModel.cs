using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeWeb.Models
{
   public class CDViewModel:DocumentViewModel
    {
        public int NbreDePlage { get; set; }
        public TimeSpan Duree { get; set; }
    }
}
