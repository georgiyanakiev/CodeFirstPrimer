namespace CodeFirstPrimer.Migrations.NHL
{
    using CodeFirstPrimer.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstPrimer.Data.NhlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\NHL";
        }

        protected override void Seed(CodeFirstPrimer.Data.NhlContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Teams.AddOrUpdate(
                t => t.TeamName, DummyData.getTeams().ToArray());
            context.SaveChanges();

            context.Players.AddOrUpdate(
                p => new { p.FirstName, p.LastName }, DummyData.getPlayers(context).ToArray());
        }
    }
}
