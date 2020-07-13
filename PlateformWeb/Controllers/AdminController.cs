using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformWeb.Buisness;
using PlateformWeb.Business.Imp;
using PlateformWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PlateformWeb.Entites;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;

namespace PlateformWeb.Controllers
{
    public class AdminController : Controller
    {
        private static  UtilisiateurBusiness utilisiateurBusiness = new UtilisateurBusinessImp();
        [VerifyUserAttribute]
        public IActionResult Index()
        {
           
            List<Utilisateur> UsersList= utilisiateurBusiness.getAllUtilisateurs();
            ViewBag.users = UsersList;
            return View( UsersList);
        }

       

        [HttpPost]
        [Route("Admin/Details")]
        [VerifyUserAttribute] 
        // GET: ProjetController/Details/5
        public JsonResult Details(int id)
        {
            String Result = "true";
            return Json(Result) ;
        }

        // GET: ProjetController/Create
        [VerifyUserAttribute]
        public ActionResult Create()
        {
            return View();
        }


        // POST: ProjetController/Create
        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Create(Utilisateur utilisateur)
        {


            utilisiateurBusiness.CreateUrilisateur(utilisateur);
            return Json("true");

           
        }

       

        // GET: ProjetController/Edit/5
        [VerifyUserAttribute]
        public ActionResult Edit(Utilisateur  util)
        {
     
            return View(util);
        }

        // POST: ProjetController/Edit/5
        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Update(Utilisateur utilisateur)
        {

            UtilisiateurBusiness utilisiateurBusiness = new UtilisateurBusinessImp();
            utilisiateurBusiness.UpdateUtilisateur(utilisateur);
            return Json("true");

          
           
        }

        
       

        // POST: ProjetController/Delete/5
        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Delete(String  idUtilisateur)
        {
            int idUtil = (int)Int64.Parse(idUtilisateur);
            
            utilisiateurBusiness = new UtilisateurBusinessImp();
            utilisiateurBusiness.DeleteUtilisateurById(idUtil);
            return Json("true");

            
        }

        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult loginCheck(string login)
        {   if (utilisiateurBusiness.checkNewLogin(login) == 1)

                return Json("true");
            else
                return Json("false");
        }



        //------------------------------------------------------------

        public class VerifyUserAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Session.GetString("Admin");
                if (user == null)
                    filterContext.Result = new RedirectResult(string.Format("/Login"));
            }
        }

    }
}
