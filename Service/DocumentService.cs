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
  public  class DocumentService:Service<Document>, IDocumetService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public DocumentService():base(unit)
        {

        }

        public IEnumerable<Document> LISTElivreDispo()
        {
          var v=  GetMany(t => t.Etat == Etat.Disponible).OfType<Livre>();
            foreach (var item in v)
            {
                Console.WriteLine("Livre"+item.Titre);
            }
            return v;
        }
    }
}
