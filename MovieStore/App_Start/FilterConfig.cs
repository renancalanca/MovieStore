using System.Web;
using System.Web.Mvc;

namespace MovieStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Redirect to error page
            filters.Add(new HandleErrorAttribute());
            //Adicionar authorized globalmente
            filters.Add(new AuthorizeAttribute());
            //Obrigar a usar o HTTPS
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
