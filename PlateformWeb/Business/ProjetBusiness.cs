using PlateformWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateformWeb.Buisness
{
    interface ProjetBusiness
    {
        List<Projet> getProjetsList(int idChefDeProjet);
        int CreateProjet(int idChef, String nomProjet);
        int UpdateProjet(Projet projet);
        Projet GetProjetById(int idChef, int idProjet);
        void DeleteProjetById(int idProjet);
        void CreateProjetFolder(int v);
        void DeleteProjetFolder(int idProjet);
        int checkNomProjet(string nomProjet);
    }
}
