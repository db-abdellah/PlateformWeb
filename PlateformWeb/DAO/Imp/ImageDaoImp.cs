using PlateformWeb.Entities;
using beta.Handlers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Dao.Imp
{
    public class ImageDaoImp : ImageDao
    {
       

        public void DeleteImageById(int idImg)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"DELETE FROM image WHERE idImage = {idImg}; ";
                connection.Execute(query);




            }
        }

        public Image getImagesById(int idImage)
        {
            List<Image> listOfImages;
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                // String query = $"SELECT * FROM image WHERE  idProjet ={projetId} ";
                String query = $"SELECT * FROM image WHERE idImage = {idImage} ";
                listOfImages = connection.Query<Image>(query).ToList();



                return listOfImages[0];
            }
        }

        public List<Image> getImagesByProjetId(int projetId)
        {
            List<Image> listOfImages;
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

               // String query = $"SELECT * FROM image WHERE  idProjet ={projetId} ";
                String query = $"SELECT * FROM image WHERE idProjet = {projetId} ";
                listOfImages = connection.Query<Image>(query).ToList();



                return listOfImages;
            }
        }

        //void ImageDao.SaveImage(Image image)
        //{

        //    using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
        //    {
                
        //            connection.Query("INSERT INTO image (nomImage, dateTransfert, idProjet,idUtilisateur) VALUES(@nomImage,@dateTransfer,@idProjet,@idUtilisateur)",
        //                new
        //                {
        //                    nomImage = image.nomImage,
        //                    dateTransfer = image.dateTransfer,
        //                    idProjet = image.idProjet,
        //                    idUtilisateur = image.idUtilisateur,
        //                });
                


        //    }

        //}
       

    }
}
