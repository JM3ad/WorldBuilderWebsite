using DataAccess.Models.Characteristics;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WorldBuilder.ViewModels
{
    public class CharacterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }

        public IEnumerable<SelectListItem> AvailableGenders { get; set; }
        public IEnumerable<SelectListItem> AvailableRaces { get; set; }
    }
}