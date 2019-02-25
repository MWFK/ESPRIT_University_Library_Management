using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
    //N'oublier pas d'activer le package system.component.dataAnnotation. dans l'assemblies
   public class Adherant
    {
        public int AdherantCode { get; set; }
        public NomComplet nomComplet { get; set; }
        [DataType(DataType.ImageUrl),Required(ErrorMessage ="la proprieté image est obligatoire")]
        public string Image { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        [Compare("MotDePasse")]
        public string ConfirmMotDePasse { get; set; }
        [Range(0,int.MaxValue)]
        public int nbAvertissement { get; set; }
        //propriétes de navigation 
        public virtual ICollection<Document> DocumentsNotes { get; set; }
        public virtual ICollection<Document> DocumentsComments { get; set; }
        public virtual ICollection<Emprunt>Emprunts { get; set; }

    }
}
