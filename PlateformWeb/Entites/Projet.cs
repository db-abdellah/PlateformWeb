using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Entities
{
    public class Projet
    {
        public int idProjet { get; set; }
       
        public String nomProjet { get; set; }

        public String dateCreationProjet { get; set; }

        public int idUtilisateur { get; set; }
        

    }
}
