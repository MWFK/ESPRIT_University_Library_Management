using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeWeb.Models
{
 public  class BibliothequeViewModel
    {
        [Key]
        public int BibliothequeCode { get; set; }
        public int NbrDoc { get; set; }
        public ICollection<DocumentViewModel> Documents{ get; set; }
    }
}
