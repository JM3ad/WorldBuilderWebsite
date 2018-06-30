using System.Collections.Generic;
using System.Linq;

namespace WorldBuilder.ViewModels
{
    public class CharacterListViewModel
    {
        public List<CharacterViewModel> Characters { get; set; }

        public CharacterListViewModel(IEnumerable<CharacterViewModel> characters)
        {
            Characters = characters.ToList();
        }
    }
}