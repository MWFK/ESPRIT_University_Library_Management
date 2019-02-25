using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
    //N'oublier pas d'activer le package system.component.dataAnnotation. dans l'assemblies
    public enum Etat { Disponible, Emprunte}
   public class Document
    {
        public int DocumentCode { get; set; }
        public Etat Etat { get; set; }
        public string Titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Categorie { get; set; }

        //les proprietes de navigation
        public virtual ICollection<Adherant> AdherantsComment { get; set; }
        public virtual ICollection<Adherant> AdherantsNote { get; set; }
        public virtual ICollection<Auteur> Auteurs { get; set; }
        public virtual ICollection<Emprunt>Emprunts { get; set; }

        //clé etrangére configuré dans la partie configuration
        public int BibliothequeFK { get; set; }
        public Bibliotheque Bibliotheque { get; set; }

    }
}
