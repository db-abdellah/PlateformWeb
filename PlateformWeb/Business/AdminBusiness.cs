using PlateformWeb.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformWeb.Business
{
    interface AdminBusiness
    {
        Admin connecterAdmin(String username, String password);
    }
}
