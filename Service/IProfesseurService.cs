using BibDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IProfesseurService:IService<Professeur>
    {
        IEnumerable<Professeur> deuxPremiersProf();
        IEnumerable<Professeur> ListProfTrie();
        IEnumerable<Professeur> ListProfTIC();
        IEnumerable<Professeur> NouvEnseignants();
    }
}
