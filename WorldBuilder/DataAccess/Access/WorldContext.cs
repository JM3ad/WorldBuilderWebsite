using DataAccess.Models;
using DataAccess.Models.Associations;
using DataAccess.Models.Characteristics;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Access
{
    public interface IMyDbContext
    {
        void AddCharacter(Character character);
        void AddLocation(Location location);
        IEnumerable<Race> GetRaces();
        IEnumerable<Gender> GetGenders();
        IEnumerable<Character> GetCharacters();
        IEnumerable<Location> GetLocations();
        Gender GetGender(int id);
        Race GetRace(int id);
        Character GetCharacter(int id);
        Location GetLocation(int id);
    }

    public class WorldContext : IdentityDbContext<User>, IMyDbContext
    {
        public WorldContext(): base("name=WorldBuilderConnectionString") {}

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CharacterLocationAssociation> CharacterLocationAssociations { get; set; }

        public IEnumerable<Race> GetRaces()
        {
            return Races;
        }

        public IEnumerable<Gender> GetGenders()
        {
            return Genders;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return Characters;
        }

        public IEnumerable<Location> GetLocations()
        {
            return Locations;
        }

        public Race GetRace(int id)
        {
            return Races.Find(id);
        }

        public Gender GetGender(int id)
        {
            return Genders.Find(id);
        }

        public Character GetCharacter(int id)
        {
            return Characters.Find(id);
        }

        public Location GetLocation(int id)
        {
            return Locations.Find(id);
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
            SaveChanges();
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
            SaveChanges();
        }
    }
}
