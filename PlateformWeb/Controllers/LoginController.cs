using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformWeb.Entities;
using PlateformWeb.Buisness;
using Microsoft.AspNetCore.Mvc;
using PlateformWeb.Business.Imp;
using PlateformWeb.DAO.Imp;
using PlateformWeb.Entites;
using Microsoft.AspNetCore.Authorization;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using PlateformWeb.Business;

namespace PlateformWeb.Controllers
{
    public class LoginController : Controller
    {
        static Utilisateur utilisateur=new Utilisateur();

        [VerifyUserAttribute]
        public IActionResult Index()
        {
            
            //ViewBag.utilisateur = utilisateur.nomUtilisateur ;
            return View();
        }


       






        [HttpPost]
       
        public JsonResult LoginCheck(String username , String password)
        {
            UtilisateurBusinessImp userBusisness = new UtilisateurBusinessImp();
            Utilisateur util =  userBusisness.connecterUtilisateur(username, password);
            AdminBusiness adminBusiness = new AdminBusinessImp();
            Admin admin = adminBusiness.connecterAdmin(username, password);
            
            if (util == null && admin== null )
           
            return Json("/login/Index");

            if (util != null)
                {
                HttpContext.Session.SetString("Chef", JsonConvert.SerializeObject(util));
                return Json("Chef");
            }
            if (admin != null) { 
                HttpContext.Session.SetString("Admin", JsonConvert.SerializeObject(admin));
                return Json("Admin");
            }
            return null;


        }


        public ActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index");
        }


        //----------------------------------------------------------------------

        public class VerifyUserAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var admin = filterContext.HttpContext.Session.GetString("Admin");
                var chef = filterContext.HttpContext.Session.GetString("Chef");
                if (admin != null)
                    filterContext.Result = new RedirectResult(string.Format("/Admin"));
                if (chef != null)
                    filterContext.Result = new RedirectResult(string.Format("/Chef"));
            }
        }

    
  


    }


}

