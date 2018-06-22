using DataAccess.Access;
using DataAccess.Models;
using System.Linq;
using WorldBuilder.ViewModels;

namespace WorldBuilder.Helpers.Factories
{
    public interface ILocationFactory
    {
        LocationViewModel CreateLocationViewModel();
        void SaveLocation(LocationViewModel viewModel);
        LocationViewModel GetLocation(int id);
    }

    public class LocationViewModelFactory : ILocationFactory
    {
        private readonly IMyDbContext context;

        public LocationViewModelFactory(IMyDbContext context)
        {
            this.context = context;
        }

        public LocationViewModel CreateLocationViewModel()
        {
            return new LocationViewModel();
        }

        public void SaveLocation(LocationViewModel viewModel)
        {
            var location = new Location
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            context.AddLocation(location);
        }

        public LocationViewModel GetLocation(int id)
        {
            var location = context.GetLocation(id);
            return new LocationViewModel(location);
        }
    }
}