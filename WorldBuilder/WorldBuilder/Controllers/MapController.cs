using System.Web.Mvc;

namespace WorldBuilder.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}