using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformWeb.Buisness;
using PlateformWeb.Buisness.Imp;
using PlateformWeb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlateformWeb.Handlers;
using Newtonsoft.Json;

namespace PlateformWeb.Controllers
{
    public class ImageController : Controller
    {
       
        private static ImageBusiness imageBusiness = new ImageBusinessImp();
        private static ProjetBusiness projetBusiness = new ProjetBusinessImp();
        

       
        [VerifyUserAttribute]
        public ActionResult Initialise(int idProjet)
        {   if(idProjet==null || idProjet ==0)
                return RedirectToAction("Images", idProjet);
            Utilisateur util = GetChefFromCookie();
            Projet projet =projetBusiness.GetProjetById(util.idUtilisateur,idProjet);
            HttpContext.Session.SetString("Projet", JsonConvert.SerializeObject(projet));

            return RedirectToAction("Images");
        }
        [VerifyUserAttribute]
        public ActionResult Images()
        {
           
            Projet projet = GetProjeFromCookie();
            if(projet == null)
                return RedirectToAction("Index","Chef");
            List<String> imagesPaths = new List<string>();
            List<Image> images = imageBusiness.getImagesByProjetId(projet.idProjet) ;
           if(images.Count == 0)
            {
                return View("ImagesError");
            }
            ViewBag.list = FileHandler.getImagesByProjet(images);
           
            return View(images);
        }

        [HttpPost]
        [VerifyUserAttribute]
        public JsonResult Delete(int idImage)
        {
          
           
              
                imageBusiness.DeleteImageById(idImage);
                return Json("true");


        }

       
        //-----------------------------------------------------------------------------------
        [HttpPost]
        [VerifyUserAttribute]
        public ActionResult getImages(int idProjet)
        {
            List<String> imagesPaths = new List<string>();
            List<Image> images = imageBusiness.getImagesByProjetId(idProjet);
            foreach (Image item in images)
            {
                String path = @"/ServerImages/" + item.idProjet + "/" + item.nomImage + ".jpg";

            }
            return Json(images);
        }
        //-----------------------------------------------------------------------------------
        [VerifyUserAttribute]
        private Projet GetProjeFromCookie()
        {
            var jsonResult = HttpContext.Session.GetString("Projet");

            return JsonConvert.DeserializeObject<Projet>(jsonResult);
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
        //--------------------------------------------------------------------------------
        [VerifyUserAttribute]
        private Utilisateur GetChefFromCookie()
        {
            var jsonResult = HttpContext.Session.GetString("Chef");

            return JsonConvert.DeserializeObject<Utilisateur>(jsonResult);
        }
    }
}
