using DataAccess.Access;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldBuilder.Helpers.Factories;

namespace WorldBuilder.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMyDbContext>().To<WorldContext>();
            Bind<ICharacterFactory>().To<CharacterViewModelFactory>();
            Bind<ILocationFactory>().To<LocationViewModelFactory>();
        }
    }
}