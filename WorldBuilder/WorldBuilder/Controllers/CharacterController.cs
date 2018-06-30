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
            characterFactory.CreateCharacter(viewModel);
            return Redirect("Index");
        }

        public ActionResult CharacterProfile(int id)
        {
            var viewModel = characterFactory.GetCharacter(id);
            return View(viewModel);
        }

        public ActionResult CharacterList()
        {
            var viewModel = characterFactory.GetAllCharacters();
            return View(viewModel);
        }

        public ActionResult EditCharacterProfile(int id)
        {
            var viewModel = characterFactory.GetCharacter(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditCharacter(CharacterViewModel viewModel)
        {
            characterFactory.UpdateCharacter(viewModel);
            return Redirect(string.Format("CharacterProfile/{0}",viewModel.Id));
        }
    }
}