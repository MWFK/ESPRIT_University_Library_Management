using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
  public  class Professeur:Adherant
    {
        public string Departement { get; set; }
        public DateTime DateDePriseDeFonction { get; set; }

        public float Salaire { get; set; }
    }
}
