using BibDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibData.Configurations
{
  public  class EmpruntConfiguration:EntityTypeConfiguration<Emprunt>
    {
        //Configuration de la clé primaire composé de trois avec fluent API
        public EmpruntConfiguration()
        {
          //  HasKey(t => new { t.AdherantCode, t.DocumentCode, t.Date });
        }
    }
}
