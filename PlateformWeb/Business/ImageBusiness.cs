using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Buisness
{
    interface ImageBusiness
    {
        List<Image> getImagesByProjetId(int idprojet);
        
        void DeleteImageById(int idImg);
    }
}
