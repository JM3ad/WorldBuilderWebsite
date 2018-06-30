using DataAccess.Access;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Helpers.Factories
{
    public interface ICharacterFactory
    {
        CharacterViewModel CreateCharacterViewModel();
        void CreateCharacter(CharacterViewModel viewModel);
        void UpdateCharacter(CharacterViewModel viewModel);
        CharacterViewModel GetCharacter(int id);
        CharacterListViewModel GetAllCharacters();
    }

    public class CharacterViewModelFactory : ICharacterFactory
    {
        private readonly IMyDbContext context;
        private readonly IEnumerable<SelectListItem> AvailableGenders;
        private readonly IEnumerable<SelectListItem> AvailableRaces;

        public CharacterViewModelFactory(IMyDbContext context)
        {
            this.context = context;
            AvailableGenders = EnumConverter.ConvertDBEnumToSelectList(context.GetGenders());
            AvailableRaces = EnumConverter.ConvertDBEnumToSelectList(context.GetRaces());
        }

        public CharacterViewModel CreateCharacterViewModel()
        {
            return new CharacterViewModel
            {
                AvailableGenders = this.AvailableGenders,
                AvailableRaces = this.AvailableRaces
            };
        }

        public void CreateCharacter(CharacterViewModel viewModel)
        {
            var character = new Character
            {
                Name = viewModel.Name,
                Gender = context.GetGender(int.Parse(viewModel.Gender)),
                Race = context.GetRace(int.Parse(viewModel.Race))
            };
            context.AddCharacter(character);
        }

        public void UpdateCharacter(CharacterViewModel viewModel)
        {
            var character = new Character
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Gender = context.GetGender(int.Parse(viewModel.Gender)),
                Race = context.GetRace(int.Parse(viewModel.Race))
            };
            context.UpdateCharacter(character);
        }

        public CharacterViewModel GetCharacter(int id)
        {
            var character = context.GetCharacter(id);
            return new CharacterViewModel(character, AvailableGenders, AvailableRaces);
        }

        public CharacterListViewModel GetAllCharacters()
        {
            var characters = context.GetCharacters();
            return new CharacterListViewModel(characters.ToList().Select(x => new CharacterViewModel(x)));
        }
    }
}