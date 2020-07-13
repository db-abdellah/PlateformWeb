using PlateformWeb.Dao;
using PlateformWeb.Dao.Imp;
using PlateformWeb.Entities;
using beta.Handlers;
using PlateformWeb.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Buisness
{
    class ImageBusinessImp : ImageBusiness
    {
        public void DeleteImageById(int idImage)
           
        {
            ImageDao imageDao = new ImageDaoImp();
            Image image =imageDao.getImagesById(idImage);
            imageDao.DeleteImageById(idImage);
            FileHandler.deleteImage(image);
        }

      

        public List<Image> getImagesByProjetId(int idprojet)
        {
            ImageDao imageDao = new ImageDaoImp();
            return imageDao.getImagesByProjetId(idprojet);
        }


       

     }

}


