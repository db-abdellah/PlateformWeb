using PlateformWeb.Entities;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.Entites
{
    public class UtilisateursModel
    {
        public Projet projet { get; set; }
        public List<Utilisateur> AuthorizedUtilisateurs { get; set; }
        public List<Utilisateur> UnAuthorizedUtilisateurs { get; set; }

    }
}
