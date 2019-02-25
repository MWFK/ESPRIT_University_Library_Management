using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliothequeWeb.Models
{
    public class AuteurViewModel
    {
        [Key]
        public int AuteurCode { get; set; }
        public NomCompletViewModel nomComplet { get; set; }
    }
}