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
   public  class EtudiantService : Service<Etudiant>,IEtudiantService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public EtudiantService() : base(unit)
        {

        }
        public int nbrtotdesetudiants()
        {
           return GetAll().Count();
        }
    }
}
