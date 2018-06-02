namespace DataAccess.Migrations
{
    using DataAccess.Access;
    using DataAccess.Migrations.Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Access.WorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorldContext context)
        {
            CharacteristicsSeeding.Run(context);
        }
    }
}
