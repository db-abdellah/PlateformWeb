using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformWeb.Buisness;
using PlateformWeb.Buisness.Imp;
using PlateformWeb.Business.Imp;
using PlateformWeb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace PlateformWeb.Controllers
{
    public class ChefController : Controller
    {
        [VerifyUserAttribute]
        public IActionResult Index()
        {
            Utilisateur chef = GetChefFromCooke();
            
            ProjetBusiness utilisiateurBusiness = new ProjetBusinessImp();
            List<Projet> projets = utilisiateurBusiness.getProjetsList(chef.idUtilisateur);
            ViewBag.chef = chef;
            ViewBag.projets = projets;
            return View(projets);

          
        }

        
        
       //------------------------------------------------------------------------------------
      
        [VerifyUserAttribute]
        private Utilisateur GetChefFromCooke()
        {
            var jsonResult = HttpContext.Session.GetString("Chef");
            
            return JsonConvert.DeserializeObject<Utilisateur>(jsonResult);
        }

        //---------------------------------------------------------------------------
        public class VerifyUserAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Session.GetString("Chef");
                if (user == null)
                    filterContext.Result = new RedirectResult(string.Format("/Login"));
            }
        }
    }
}
