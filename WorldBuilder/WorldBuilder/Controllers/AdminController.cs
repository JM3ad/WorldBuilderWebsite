using System.Web.Mvc;

namespace WorldBuilder.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}