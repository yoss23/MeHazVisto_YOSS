using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MHV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");// "axd" IGNORA CUALQUIER DOCUMENTO CON LA EXTENSION axd DIRECCIONES A CONTENIDO REAL EN EL SERVIDOR

            //MapRoute mapear las peticiones con los controladores y los action methods

            routes.MapRoute(//plantilla de ruteo define como se rutearan peticiones http en los controllers
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }//parametros para el servidor HTTP
                //si no se establece un id=Urlparameter marca errores al ejecutarla
            );
        }
    }
}