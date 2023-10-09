namespace DataModels.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.PracticeOnClassDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(EF.PracticeOnClassDbContext context)
        {

        }
    }
}
