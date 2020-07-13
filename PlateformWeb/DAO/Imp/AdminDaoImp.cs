using beta.Handlers;
using Dapper;
using PlateformWeb.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.DAO.Imp
{
    public class AdminDaoImp : AdminDao
    {
        public Admin GetAdminByLogin(string username, string password)
        {
            using (IDbConnection connection = ConnectionHandler.Instance.getConnection())
            {

                List<Admin> admin = connection.Query<Admin>($"SELECT * FROM administrateur WHERE  loginAdministrateur = '{username}' AND motDePasseAdministrateur ='{password}'").ToList();


                if (admin.Count > 0)
                    return admin[0];
                else return null;
            }
        }

       
    }
}
