
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
 public   class AuteurService: Service<Auteur>,IAuteurService
    {
      private static  IDatabaseFactory dbfactory = new DatabaseFactory();
     private static   IUnitOfWork ut = new UnitOfWork(dbfactory);
        public AuteurService():base(ut)
        {

        }
    }
}
