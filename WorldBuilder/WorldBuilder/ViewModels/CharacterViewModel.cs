using DataAccess.Models;
using DataAccess.Models.Characteristics;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WorldBuilder.ViewModels
{
    public class CharacterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GenderId { get; set; }
        public string RaceId { get; set; }

        public IEnumerable<SelectListItem> AvailableGenders { get; set; }
        public IEnumerable<SelectListItem> AvailableRaces { get; set; }

        public CharacterViewModel() {}

        public CharacterViewModel(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Description = character.Description;
            GenderId = character.Gender.Id.ToString();
            RaceId = character.Race.Id.ToString();
        }

        public CharacterViewModel(Character character, IEnumerable<SelectListItem> availableGenders, IEnumerable<SelectListItem> availableRaces) : this(character)
        {
            AvailableGenders = availableGenders;
            AvailableRaces = availableRaces;
            AvailableGenders.First(g => g.Value == GenderId).Selected = true;
            AvailableRaces.First(r => r.Value == RaceId).Selected = true;
        }
    }
}