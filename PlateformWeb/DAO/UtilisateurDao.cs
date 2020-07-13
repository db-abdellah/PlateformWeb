using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Dao
{
    interface UtilisateurDao
    {
        Utilisateur GetUtilisateurByLogin(String username, String password);
        List<Utilisateur> getAllUtilisateurs();
        void CreateUtilisateur(Utilisateur utilisateur);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateurById(int userId);
        List<Utilisateur> getUtilisateursByProjetAcces(int idProjet);
        int checkNewLogin(string login);
        List<Utilisateur> getUtilisateursByUnauthorizedProjetAcces(int idProjet);
        void giveUtilisateurAcces( int idProjet,  int idUtilisateur);
        void removeUtilisateurAcces( int idProjet,  int idUtilisateur);
        Utilisateur getUtilisateurById(int idUtilisateur);
    }
}
