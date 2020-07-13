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
    class ProjetDaoImp : ProjetDao
    {
        public int checkNomProjet(string nomProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"SELECT idProjet FROM projet  WHERE  nomProjet	 ='{nomProjet}' ";
                List<Projet> projet = connection.Query<Projet>(query).ToList();


                if (projet.Count > 0)
                    return 0;
                else
                    return 1;
            }
        }

        public int CreateProjet(int idChef, string nomProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"INSERT INTO projet(nomProjet, dateCreationProjet, idUtilisateur) VALUES('{nomProjet}', CURRENT_TIMESTAMP,{idChef}); SELECT LAST_INSERT_ID() as id; ";
                dynamic result = connection.Query(query).First();
               

                int idProjet = (int)result.id;
                Console.WriteLine(idProjet);
                return idProjet;
            }
        }

        public void deleteAccess(int idProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"DELETE FROM acces WHERE idProjet = {idProjet}; ";
                connection.Execute(query);




            }
        }

        public void DeleteProjetById(int idProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"DELETE FROM projet WHERE idProjet = {idProjet}; ";
                connection.Execute(query);




            }
        }

        public Projet GetProjetById(int idChef, int idProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"SELECT * FROM projet  WHERE  idProjet ='{idProjet}' AND idUtilisateur ='{idChef}'";
                List<Projet > projet = connection.Query<Projet>(query).ToList();



                return projet[0];
            }
        }

        public List<Projet> GetProjetsByChefDeProjet(int idChefDeProjet)
        {
            List<Projet> listOfProjects;
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"SELECT * FROM projet  WHERE  idUtilisateur ='{idChefDeProjet}'";
                listOfProjects = connection.Query<Projet>(query).ToList();



                return listOfProjects;
            }
        }

        public void UpdateProjet(Projet projet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"UPDATE projet  SET nomProjet = '{projet.nomProjet}' WHERE idProjet = {projet.idProjet} ";
                connection.Execute(query);




            }
        }
    }
}
