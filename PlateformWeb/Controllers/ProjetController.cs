using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformWeb.Buisness;
using PlateformWeb.Buisness.Imp;
using PlateformWeb.Business.Imp;
using PlateformWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis;
using PlateformWeb.Entites;
using Newtonsoft.Json;

namespace PlateformWeb.Controllers
{
    public class ProjetController : Controller
    {
        private static ProjetBusiness projetBusiness = new ProjetBusinessImp();
        private static UtilisiateurBusiness utilisiateurBusiness = new UtilisateurBusinessImp();

       

        // Create projet page
        [VerifyUserAttribute]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Create projet
        [VerifyUserAttribute]
        [HttpPost]
        public JsonResult Create(string nomProjet)
        {

            Utilisateur chef = GetChefFromCookie();
            int idProjet = projetBusiness.CreateProjet(chef.idUtilisateur, nomProjet);
            projetBusiness.CreateProjetFolder(idProjet);
            utilisiateurBusiness.giveUtilisateurAcces(idProjet, chef.idUtilisateur);
            return Json("true");

        }



        //Delete Projet
        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Delete(int idProjet)
        {


            projetBusiness.DeleteProjetById(idProjet);
            projetBusiness.DeleteProjetFolder(idProjet);
            return Json("true");




        }


        //Edit page

        [VerifyUserAttribute]
        public ActionResult Edit(int idProjet)
        {
            Utilisateur chef = GetChefFromCookie();
            Projet projet= projetBusiness.GetProjetById(chef.idUtilisateur, idProjet);
            if (projet != null)
                return View(projet);
            return RedirectToAction("Index", "Chef");

        }





        //projet infos update
        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Update(Projet projet)
        {
            
                ProjetBusiness projetBusiness = new ProjetBusinessImp();
                projetBusiness.UpdateProjet(projet);
                return Json("true");
        }


        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult ProvideAcces(String idProjet,String idUtilisateur)
        {
            int projetId = int.Parse(idProjet);
            int utilId = int.Parse(idUtilisateur);
            utilisiateurBusiness.giveUtilisateurAcces(projetId, utilId);
            return Json("true");
        }


        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult DenyAcces(String idProjet, String idUtilisateur)
        {
            int projetId = int.Parse(idProjet);
            int utilId = int.Parse(idUtilisateur);
            utilisiateurBusiness.removeUtilisateurAcces(projetId, utilId);
            return Json("true");
        }




        //Acces Management
        [VerifyUserAttribute]
        public ActionResult Acces(int idProjet)
        {
            UtilisateursModel model = new UtilisateursModel();
            Utilisateur chef = GetChefFromCookie();
            Projet projet = projetBusiness.GetProjetById(chef.idUtilisateur, idProjet) ;
            model.projet = projet;
            model.AuthorizedUtilisateurs = utilisiateurBusiness.getUtilisateursByProjetAcces(projet.idProjet);
            model.UnAuthorizedUtilisateurs = utilisiateurBusiness.getUtilisateursByUnauthorizedProjetAcces(projet.idProjet);
            return View(model);
        }


        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult ProjetCheck(string nomProjet)
        {
            if (projetBusiness.checkNomProjet(nomProjet) == 1)
                return Json("true");
            else
                return Json("false");
        }

        //--------------------------------------------------------------------------------------

        [VerifyUserAttribute]
        private Utilisateur GetChefFromCookie()
        {
            var jsonResult = HttpContext.Session.GetString("Chef");

            return JsonConvert.DeserializeObject<Utilisateur>(jsonResult);
        }


        //-----------------------------------------------------------------------------------

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
