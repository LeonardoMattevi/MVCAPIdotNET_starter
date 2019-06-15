namespace MVCAPIdotNET_starter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCAPIdotNET_starter.Models.Domain.DB.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCAPIdotNET_starter.Models.Domain.DB.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            Code.Manager.ManagerSeedDB.SeedMe(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
