using BibDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibData.Configurations
{
   public class DocumentConfiguration:EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            HasMany<Adherant>(y => y.AdherantsComment).WithMany(o => o.DocumentsComments).Map(t => t.ToTable("Comment"));
            HasMany<Adherant>(y => y.AdherantsNote).WithMany(o => o.DocumentsNotes).Map(t => t.ToTable("Note"));
            
            //one to many relation
            HasRequired<Bibliotheque>(t => t.Bibliotheque).WithMany(t => t.Documents).HasForeignKey(t => t.BibliothequeFK).WillCascadeOnDelete(true);
            
            //Many To Many relation
            HasMany<Auteur>(y => y.Auteurs).WithMany(o => o.Documents).Map(t => t.ToTable("AuthDoc"));
            //stratégie d'heritage TPH : changer le nom du champ discriminator 
           
            Map<CD>(c =>
            {
                c.Requires("Type").HasValue(1); //Type is the descriminator
            });
            Map<Livre>(c =>
            {
                c.Requires("Type").HasValue(0);
            });
        }
    }
    }

