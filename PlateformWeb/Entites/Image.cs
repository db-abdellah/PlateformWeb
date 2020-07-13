using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Entities
{
    public class Image
    {
        public int idImage { get; set; }


        public String nomImage { get; set; }

        public String pathImage { get; set; }

        public DateTime dateTransfer { get; set; }

        public int idProjet { get; set; }

        public int idUtilisateur { get; set; }

        public Image(String pathImage,int idUtilisateur,int idProjet)
        {
            this.idProjet = idProjet;
            this.idUtilisateur = idUtilisateur;
            this.pathImage = pathImage;
            this.nomImage = Path.GetFileNameWithoutExtension(pathImage);


        }
        public Image() { }





    }
}
