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
   public class EmpruntService:Service<Emprunt>,IEmpruntService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EmpruntService() : base(unit)
        {

        }
        public void AutorisationEmprunt(Emprunt E)
        {
            var Em = GetAll();//prend tt les emprunt
            var A = unit.getRepository<Professeur>().GetAll();
            var B = unit.getRepository<Document>().GetAll();

            var query = (
                             from i in B
                             from k in A
                             join l in GetAll() //je crois Em doit etre utiliser ici 
                                                on new { i.DocumentCode, k.AdherantCode } 
                                                equals new { l.DocumentCode, l.AdherantCode }
                             where l.Doc.Etat ==Etat.Disponible && l.Date.Year==DateTime.Now.Year
                             select l
                         ).Count();
            
           
                if (query <3)
                {
                    Add(E);
                    Commit();
                }
                else
                    Console.WriteLine("vous avez depassé le nombre limite d emprunt");
        }
    }
}
