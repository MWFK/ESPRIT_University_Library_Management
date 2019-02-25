using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDomain.Entities
{
    //N'oublier pas d'activer le package system.component.dataAnnotation. dans l'assemblies

    //classe porteuse de données
    [Table("EmpruntLivre")]
    public class Emprunt
    {
        [Key , Column(Order=0)]
        public int DocumentCode { get; set; }
        [Key, Column(Order = 1)]
        public int AdherantCode { get; set; }
        [Key, Column(Order = 2)]
        public DateTime Date { get; set; }
        public Document Doc { get; set; }
        public Adherant Adh { get; set; }
    }
}
