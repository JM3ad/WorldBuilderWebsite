using System.Web.Mvc;
using WorldBuilder.Helpers.Factories;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterFactory characterFactory;

        public CharacterController(ICharacterFactory characterFactory)
        {
            this.characterFactory = characterFactory;
        }

        public ActionResult Index()
        {
            var viewModel = characterFactory.CreateCharacterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateCharacter(CharacterViewModel viewModel)
        {
            characterFactory.SaveCharacter(viewModel);
            return Redirect("Index");
        }

        public ActionResult CharacterProfile(int id)
        {
            var viewModel = characterFactory.GetCharacter(id);
            return View(viewModel);
        }
    }
}