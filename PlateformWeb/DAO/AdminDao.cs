using PlateformWeb.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.DAO
{
    interface AdminDao
    {
        Admin GetAdminByLogin(String username, String password);
    }
}
