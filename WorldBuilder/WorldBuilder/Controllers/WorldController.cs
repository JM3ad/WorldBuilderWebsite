using System.Web.Mvc;
using WorldBuilder.Helpers.Factories;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Controllers
{
    public class WorldController : Controller
    {

        private readonly ILocationFactory locationFactory;

        public WorldController(ILocationFactory locationFactory)
        {
            this.locationFactory = locationFactory;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateLocation()
        {
            return View(new LocationViewModel());
        }

        [HttpPost]
        public ActionResult CreateLocation(LocationViewModel viewModel)
        {
            locationFactory.SaveLocation(viewModel);
            return Redirect("Index");
        }

        public ActionResult Location(int id)
        {
            var viewModel = locationFactory.GetLocation(id);
            return View(viewModel);
        }
    }
}