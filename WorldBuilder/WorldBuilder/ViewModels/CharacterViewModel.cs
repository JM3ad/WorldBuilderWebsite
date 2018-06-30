using DataAccess.Models;
using DataAccess.Models.Characteristics;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WorldBuilder.ViewModels
{
    public class CharacterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }

        public IEnumerable<SelectListItem> AvailableGenders { get; set; }
        public IEnumerable<SelectListItem> AvailableRaces { get; set; }

        public CharacterViewModel() {}

        public CharacterViewModel(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Description = character.Description;
            Gender = character.Gender.ToString();
            Race = character.Race.ToString();
        }

        public CharacterViewModel(Character character, IEnumerable<SelectListItem> availableGenders, IEnumerable<SelectListItem> availableRaces) : this(character)
        {
            AvailableGenders = availableGenders;
            AvailableRaces = availableRaces;
        }
    }
}