using DataAccess.Access;
using DataAccess.Models.Characteristics;
using System.Data.Entity.Migrations;

namespace DataAccess.Migrations.Seeds
{
    public static class CharacteristicsSeed
    {
        public static void Run(WorldContext context)
        {
            SeedGenders(context);
            SeedRaces(context);
        }

        public static void SeedGenders(WorldContext context)
        {
            context.Genders.AddOrUpdate(new Gender[] { new Gender { Id=1, Name="Male" },new Gender { Id=2, Name="Female" } });
        }

        public static void SeedRaces(WorldContext context)
        {
            context.Races.AddOrUpdate(new Race[] {
                new Race{Id = 1, Name = "Human" },
                new Race{Id = 2, Name = "Elf" },
                new Race{Id = 3, Name = "Half Elf" },
                new Race{Id = 4, Name = "Gnome" } 
            });
        }
    }
}
