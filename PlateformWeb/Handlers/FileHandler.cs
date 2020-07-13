using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.Handlers
{
    public static class FileHandler
    {
        private static String mainFolder = ConfigurationManager.AppSettings["MainFolder"].ToString();

        public static void deleteImage(Image image)
        {
            String path = mainFolder+ image.idProjet + "/" + image.nomImage + ".jpg";
            File.Delete(path);
        }
        public static void deleteProjet(int idProjet)
         {
            String path = mainFolder + idProjet  ;
            Directory.Delete(path);
         }

        

        public static List<String> getImagesByProjet(List<Image> images)
        {
            List<String> pathList = new List<String>();

            String path = String.Empty;
            foreach (Image img in images)
            {
               path = @"/ServerImages/" + img.idProjet + "/" +img.nomImage +".jpg";
               
                pathList.Add(path);
            }


            return pathList;

        }

        public static void CreateProjet(int idProjet)
        {
            
            String path = mainFolder  + idProjet ;

            Directory.CreateDirectory(path);
        }


    }
}
