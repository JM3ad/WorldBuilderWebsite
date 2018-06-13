using DataAccess.Access;
using DataAccess.Models;
using DataAccess.Models.Characteristics;
using System.Linq;
using System.Web.Mvc;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Helpers.Factories
{
    public interface ICharacterFactory
    {
        CharacterViewModel CreateCharacterViewModel();
        void SaveCharacter(CharacterViewModel viewModel);
    }

    public class CharacterViewModelFactory : ICharacterFactory
    {
        private readonly IMyDbContext context;

        public CharacterViewModelFactory(IMyDbContext context)
        {
            this.context = context;
        }

        public CharacterViewModel CreateCharacterViewModel()
        {
            return new CharacterViewModel
            {
                AvailableGenders = EnumConverter.ConvertDBEnumToSelectList(context.GetGenders()),
                AvailableRaces = EnumConverter.ConvertDBEnumToSelectList(context.GetRaces())
            };
        }

        public void SaveCharacter(CharacterViewModel viewModel)
        {
            var character = new Character
            {
                Name = viewModel.Name,
                Gender = context.GetGender(int.Parse(viewModel.Gender)),
                Race = context.GetRace(int.Parse(viewModel.Race))
            };
            context.AddCharacter(character);
        }
    }
}