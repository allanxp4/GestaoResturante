using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    [Authorize]
    public class IndexController : Controller
    {
        #region GET
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion GET
    }
}