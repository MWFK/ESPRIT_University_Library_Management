using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeWeb.Models
{
  public  class ProfesseurViewModel:AdherantViewModel
    {
        public string Departement { get; set; }
        public DateTime DateDePriseDeFonction { get; set; }

        public float Salaire { get; set; }
    }
}
