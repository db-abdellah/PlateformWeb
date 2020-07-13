using PlateformWeb.Entities;
using PlateformWeb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlateformWeb.Dao.Imp;
using PlateformWeb.Handlers;
using PlateformWeb.Buisness;

namespace PlateformWeb.Buisness.Imp
{
    class ProjetBusinessImp : ProjetBusiness
    {
        public int checkNomProjet(string nomProjet)
        {
            ProjetDao daoProjet = new ProjetDaoImp();
            return daoProjet.checkNomProjet(nomProjet);
        }

        public int  CreateProjet(int idChef, string nomProjet)
        {
           
                ProjetDao daoProjet = new ProjetDaoImp();
               
                int idProjet= daoProjet.CreateProjet(idChef, nomProjet);

            return idProjet;


        }

        public void CreateProjetFolder(int idProjet)
        {
            FileHandler.CreateProjet(idProjet);
        }

        public void DeleteProjetById(int idProjet)
        {

            ProjetDao daoProjet = new ProjetDaoImp();
            daoProjet.DeleteProjetById(idProjet);
            daoProjet.deleteAccess(idProjet);
        }

        public void DeleteProjetFolder(int idProjet)
        {
            FileHandler.deleteProjet(idProjet);
        }

        public Projet GetProjetById(int idChef, int idProjet)
        {
            ProjetDao daoProjet = new ProjetDaoImp();
            return daoProjet.GetProjetById(idChef,idProjet);
        }

        public List<Projet> getProjetsList(int idChefDeProjet)
        {
            ProjetDao daoProjet = new ProjetDaoImp();
            return daoProjet.GetProjetsByChefDeProjet(idChefDeProjet);
        }

        public int UpdateProjet(Projet projet)
        {
            try
            {
                ProjetDao utilisateurDao = new ProjetDaoImp();
                utilisateurDao.UpdateProjet(projet);
                return 1;

            }
            catch
            {
                return -1;
            }
        }
    }
}
