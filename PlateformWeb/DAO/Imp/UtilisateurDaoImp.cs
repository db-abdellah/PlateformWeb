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
    class UtilisateurDaoImp : UtilisateurDao
    {
        Utilisateur UtilisateurDao.GetUtilisateurByLogin(string username, string password)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
               
                List<Utilisateur> util = connection.Query<Utilisateur>($"SELECT * FROM utilisateur WHERE  loginUtilisateur = '{username}' AND motDePasseUtilisateur ='{password}' AND fonctionUtilisateur = 'Chef'").ToList();
                Console.WriteLine(util.Count)
                    ;
                if (util.Count > 0)
                    return util[0];
                else return null;
            }
        }
        public List<Utilisateur> getAllUtilisateurs()
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                List<Utilisateur> chefs = connection.Query<Utilisateur>($"SELECT * FROM utilisateur ").ToList();
               
                
                return chefs;
            }
        }

        public void CreateUtilisateur(Utilisateur util)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = 
                    $"INSERT INTO utilisateur(nomUtilisateur,prenomUtilisateur,loginUtilisateur,motDePasseUtilisateur,dateCreationUtilisateur,fonctionUtilisateur) VALUES('{util.nomUtilisateur}','{util.prenomUtilisateur} ','{util.loginUtilisateur}','{util.motDePasseUtilisateur}', CURRENT_TIMESTAMP,'{util.fonctionUtilisateur}') ";
                connection.Execute(query);



               
            }
        }

        public void UpdateUtilisateur(Utilisateur util)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query =
                    $"UPDATE utilisateur  SET nomUtilisateur = '{util.nomUtilisateur}', prenomUtilisateur = '{util.prenomUtilisateur}',loginUtilisateur= '{util.loginUtilisateur}', motDePasseUtilisateur= '{util.motDePasseUtilisateur}', fonctionUtilisateur  = '{util.fonctionUtilisateur}' WHERE idUtilisateur = {util.idUtilisateur} ";
                connection.Execute(query);




            }
        }

        public void DeleteUtilisateurById(int userId)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"DELETE FROM utilisateur WHERE idUtilisateur = {userId}; ";
                connection.Execute(query);




            }
        }

        public List<Utilisateur> getUtilisateursByProjetAcces(int idProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                String query = @$"SELECT utilisateur.idUtilisateur, `nomUtilisateur`, `prenomUtilisateur`FROM `utilisateur`,acces
                                WHERE utilisateur.idUtilisateur= acces.idUtilisateur
                                AND acces.idProjet = {idProjet} ";
                List<Utilisateur> listUtil = connection.Query<Utilisateur>(query).ToList();


                Console.WriteLine(listUtil.Count);

                return listUtil;
            }
        }

        public List<Utilisateur> getUtilisateursByUnauthorizedProjetAcces(int idProjet)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                String query = @$"SELECT `idUtilisateur`, `nomUtilisateur`, `prenomUtilisateur`, `fonctionUtilisateur` 
                                FROM utilisateur WHERE utilisateur.idUtilisateur NOT IN ( SELECT idUtilisateur from acces WHERE acces.idProjet = {idProjet})
                                ; ";
                List<Utilisateur> listUtil = connection.Query<Utilisateur>(query).ToList();


                Console.WriteLine(listUtil.Count);

                return listUtil;
            }
        }

        public void giveUtilisateurAcces(int idProjet, int idUtilisateur)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query =
                    $"INSERT INTO acces(date,idProjet,idUtilisateur) VALUES( CURRENT_TIMESTAMP,'{idProjet} ','{idUtilisateur}') ";
                connection.Execute(query);

                    


            }
        }

        public void removeUtilisateurAcces(int idProjet,  int idUtilisateur)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {
                String query = $"DELETE FROM acces WHERE idUtilisateur = {idUtilisateur} AND idProjet = {idProjet}; ";
                connection.Execute(query);




            }
        }

        public Utilisateur getUtilisateurById(int idUtilisateur)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                List<Utilisateur> util = connection.Query<Utilisateur>($"SELECT * FROM utilisateur WHERE  idUtilisateur = '{idUtilisateur}'").ToList();
               
                
                    return util[0];
                
            }
        }

        public int checkNewLogin(string login)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                List<Utilisateur> util = connection.Query<Utilisateur>($"SELECT idUtilisateur FROM utilisateur WHERE  loginUtilisateur = '{login}'").ToList();

                if (util.Count > 0)
                    return 0;
                else 
                    return 1;

            }
        }
    }
}
