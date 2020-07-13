using PlateformWeb.DAO;
using PlateformWeb.DAO.Imp;
using PlateformWeb.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.Business.Imp
{
    public class AdminBusinessImp : AdminBusiness
    {
        public Admin connecterAdmin(string username, string password)
        {
            
                AdminDao adminDao = new AdminDaoImp();
              
                Admin admin = adminDao.GetAdminByLogin(username, password);

                return admin;
           
        }
    }
}
