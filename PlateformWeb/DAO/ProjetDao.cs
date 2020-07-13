using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Dao
{
    interface ProjetDao
    {
        List<Projet> GetProjetsByChefDeProjet(int idChefDeProjet);
        int CreateProjet(int idChef, String nomProjet);
        void UpdateProjet(Projet projet);
        Projet GetProjetById(int idChef, int idProjet);
        void DeleteProjetById(int idProjet);
        int checkNomProjet(string nomProjet);
        void deleteAccess(int idProjet);
    }
}
