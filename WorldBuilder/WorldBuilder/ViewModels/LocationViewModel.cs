using DataAccess.Models;

namespace WorldBuilder.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LocationViewModel() { }
        public LocationViewModel(Location location)
        {
            Id = location.Id;
            Name = location.Name;
            Description = location.Description;
        }
    }
}