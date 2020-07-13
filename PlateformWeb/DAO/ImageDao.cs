using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Dao
{
    interface ImageDao
    {
        List<Image> getImagesByProjetId(int projetId);
       
        void DeleteImageById(int idImg);
        Image getImagesById(int idImage);
    }
}
