using DataAccess.Models;
using DataAccess.Models.Characteristics;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Access
{
    public interface IMyDbContext
    {
        void AddCharacter(Character character);
        IEnumerable<Race> GetRaces();
        IEnumerable<Gender> GetGenders();
        IEnumerable<Character> GetCharacters();
        Gender GetGender(int id);
        Race GetRace(int id);
        Character GetCharacter(int id);
    }

    public class WorldContext : IdentityDbContext<User>, IMyDbContext
    {
        public WorldContext(): base("name=WorldBuilderConnectionString") {}

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Gender> Genders { get; set; }

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

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
            SaveChanges();
        }
    }
}
