using System.Web;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Services
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
