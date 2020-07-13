using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Buisness
{
    interface UtilisiateurBusiness
    {
        Utilisateur connecterUtilisateur(String username, String password);
        List<Utilisateur> getAllUtilisateurs();
        int CreateUrilisateur(Utilisateur utilisateur);
        int UpdateUtilisateur(Utilisateur util);
        int DeleteUtilisateurById(int userId);
        List<Utilisateur> getUtilisateursByProjetAcces(int idProjet);
        List<Utilisateur> getUtilisateursByUnauthorizedProjetAcces(int idProjet);

        void giveUtilisateurAcces(int idProjet, int idUtilisateur);
        void removeUtilisateurAcces(int idProjet, int idUtilisateur);
        Utilisateur getUtilisateurById(int idUtilisateur);
        int checkNewLogin(string login);
    }
}
