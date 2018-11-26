using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*Criar do mais especifico para o menos*/

            /*Modo mas recente de criar ROUTES*/
            routes.MapMvcAttributeRoutes();

            /*Até os ASP.NET MVC 5 era utilizado essa forma de criar ROUTES, porém ele é muito frágil por ser só string*/
            /*routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate" },
                Adicionando constraint para URL através do REGEX
                new { year = @"\d{4}", month = @"\d{2}" }
                );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
