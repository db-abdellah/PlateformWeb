using PlateformWeb.Buisness;
using PlateformWeb.Buisness.Imp;
using PlateformWeb.Dao;
using PlateformWeb.Dao.Imp;
using PlateformWeb.Entities;
using PlateformWeb.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Business.Imp
{
    class UtilisateurBusinessImp : UtilisiateurBusiness
    { 
          UtilisateurDao utilDao = new UtilisateurDaoImp();
          ProjetDao projetDao = new ProjetDaoImp();

        public int checkNewLogin(string login)
        {
            return utilDao.checkNewLogin(login);
        }

        public Utilisateur connecterUtilisateur(string username, string password)
        {
          
            Utilisateur utilisateur = utilDao.GetUtilisateurByLogin(username, password);

            return utilisateur;
        }

        public int CreateUrilisateur(Utilisateur utilisateur)
        {
            try
            {
               
                utilDao.CreateUtilisateur(utilisateur);
                return 1;

            }
            catch
            {
                return -1;
            }
        }

        public int DeleteUtilisateurById(int userId)
        {
            try
            {
               
                utilDao.DeleteUtilisateurById(userId);
                ProjetBusiness projetBusiness = new ProjetBusinessImp();
                List<Projet> projetsList =projetBusiness.getProjetsList(userId);
                foreach(Projet projet in projetsList)
                {
                    FileHandler.deleteProjet(projet.idProjet);
                    projetDao.deleteAccess(projet.idProjet);
                }

                return 1;

            }
            catch
            {
                return -1;
            }
        }

        public List<Utilisateur> getAllUtilisateurs()
        {
            List<Utilisateur> chefs = utilDao.getAllUtilisateurs();
            return chefs;
        }

        public Utilisateur getUtilisateurById(int idUtilisateur)
        {
            return utilDao.getUtilisateurById(idUtilisateur);
        }

        public List<Utilisateur> getUtilisateursByProjetAcces(int idProjet)
        {
            List<Utilisateur> utilisateur = utilDao.getUtilisateursByProjetAcces(idProjet);

            return utilisateur;
        }

        public List<Utilisateur> getUtilisateursByUnauthorizedProjetAcces(int idProjet)
        {
            List<Utilisateur> utilisateur = utilDao.getUtilisateursByUnauthorizedProjetAcces(idProjet);

            return utilisateur;
        }

        public void giveUtilisateurAcces(int idProjet, int idUtilisateur)
        {
            utilDao.giveUtilisateurAcces(idProjet, idUtilisateur);
        }

        public void removeUtilisateurAcces(int idProjet, int idUtilisateur)
        {
            utilDao.removeUtilisateurAcces(idProjet, idUtilisateur);
        }

        public int UpdateUtilisateur(Utilisateur util)
        {
            try
            {
                utilDao.UpdateUtilisateur(util);
                return 1;

            }
            catch
            {
                return -1;
            }
        }
    }
}
