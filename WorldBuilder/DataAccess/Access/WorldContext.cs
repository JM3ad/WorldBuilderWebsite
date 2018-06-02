using DataAccess.Models;
using DataAccess.Models.Characteristics;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataAccess.Access
{
    public class WorldContext : IdentityDbContext<User>
    {
        public WorldContext(): base("name=WorldBuilderConnectionString") {}

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}
