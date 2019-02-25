using BibData.Infrastructure;
using BibDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class ProfesseurService : Service<Professeur>,IProfesseurService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ProfesseurService() : base(unit)
        {

        }
        public IEnumerable<Professeur> ListProfTrie()
        {
           var c= GetAll().OrderByDescending(t => t.AdherantCode);
            foreach (var item in c)
            {
                Console.WriteLine("code "+item.AdherantCode + "Nom et prenom"+item.nomComplet);
            }
            return c;
        }
        public IEnumerable<Professeur> deuxPremiersProf()
        {
            var c = GetAll().OrderBy(t => t.Salaire).Take(2);
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.AdherantCode + " Nom " + item.nomComplet.Nom+" salaire "+item.Salaire);
            }
            return c;
        }
        public IEnumerable<Professeur> ListProfTIC()
        {
            var c = GetMany(t=>t.Departement=="TIC");
            foreach (var item in c)
            {
                Console.WriteLine(" code " + item.AdherantCode + " Nom " + item.nomComplet.Nom + " Departement" + item.Departement);
            }
            return c;
        }
        public IEnumerable<Professeur> NouvEnseignants()
        {

            var req = (from i in GetAll()
                       where DateTime.Now.Year - i.DateDePriseDeFonction.Year == 0 && DateTime.Now.Month - i.DateDePriseDeFonction.Month < 6 || DateTime.Now.Year - i.DateDePriseDeFonction.Year <= 1 && DateTime.Now.Month + 12 - i.DateDePriseDeFonction.Month <= 6 && i.Departement=="TIC"
                       select i);

            foreach (var item in req)
            {
                Console.WriteLine("les prof dans le departement TIC : "+item.nomComplet.Nom+" Date de Fonction"+item.DateDePriseDeFonction);
            }
            return req;

        }
    }
}
