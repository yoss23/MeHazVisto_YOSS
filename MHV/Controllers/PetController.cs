using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MHV.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/

        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult Display()
        {
          /*  var name = (string)RouteData.Values["id"];//obtener el string que invoco a la url los Values son para decir o que se quiere saber de la url

            var model = PetManagment.GetByName(name);
            if (model == null)
                return RedirectToAction("NotFound");
            return View(model);*/
            var name = (string)RouteData.Values["id"];
            object model = null;
            if (model == null)
            
            return RedirectToAction("NotFound");
            return View();  
        }

        public ActionResult NotFound()
        {
            ViewBag.ErrorCode= "NFE0001";//diccionario con una clave que se le asigna un valor
            ViewBag.Descripcion = "La mascota no se encuentra" + " en la base de datos";

           /* ViewData["ErrorCode"] = "NFE0001";//diccionario con una clave que se le asigna un valor
            ViewData["Descripcion"] = "La mascota no se encuentra" + "en la base de datos";
            */
            return View();
        }

        public FileResult DownLoadPicture()
        {
            var name = (string)RouteData.Values["id"];
            var picture ="/Content/Uploads" + name + ".jpg";//obtener el string que invoco a la url los Values son para decir o que se quiere saber de la url
            var contentType = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture, contentType, fileName);
        }

      public HttpStatusCodeResult UnauthorizedError()
        {
           return new  HttpUnauthorizedResult("Error acceso no autorizado");
        
        }

        public ActionResult NotFoundError()
        {

            return HttpNotFound("Nada por aqui...");
        }

        //actionMethod que permite la carga de  la foto de la mascota
        public ActionResult PictureUpload()
        {
            return View();
        }
    }
}
