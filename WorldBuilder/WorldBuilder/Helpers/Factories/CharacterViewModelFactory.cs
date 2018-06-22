using DataAccess.Access;
using DataAccess.Models;
using System.Linq;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Helpers.Factories
{
    public interface ICharacterFactory
    {
        CharacterViewModel CreateCharacterViewModel();
        void SaveCharacter(CharacterViewModel viewModel);
        CharacterViewModel GetCharacter(int id);
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

        public CharacterViewModel GetCharacter(int id)
        {
            var character = context.GetCharacter(id);
            return new CharacterViewModel(character);
        }
    }
}