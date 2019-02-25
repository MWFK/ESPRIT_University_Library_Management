using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeWeb.Models
{
    //N'oublier pas d'activer le package system.component.dataAnnotation. dans l'assemblies
    public enum Etat { Disponible, Emprunte}
   public class DocumentViewModel
    {
        [Key]
        public int DocumentCode { get; set; }
        public Etat Etat { get; set; }
        public string Titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Categorie { get; set; }
        //clé etrangére configuré dans la partie configuration
        public int BibliothequeFK { get; set; }
        //les proprietes de navigation
        public virtual ICollection<AdherantViewModel> AdherantsComment { get; set; }
        public virtual ICollection<AdherantViewModel> AdherantsNote { get; set; }
        public virtual ICollection<AuteurViewModel> Auteurs { get; set; }
        public virtual ICollection<EmpruntViewModel>Emprunts { get; set; }
        public BibliothequeViewModel Bibliotheque { get; set; }

    }
}
