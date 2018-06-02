using DataAccess.Access;
using System.Web.Mvc;

namespace WorldBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to world builder";

            return View();
        }
    }
}