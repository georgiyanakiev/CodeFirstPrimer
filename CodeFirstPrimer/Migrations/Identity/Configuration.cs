namespace CodeFirstPrimer.Migrations.Identity
{
    using CodeFirstPrimer.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstPrimer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ApplicationDbContext context) {
            var roleManager = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Guest"))
                roleManager.Create(new IdentityRole("Guest"));

            var userManager = new UserManager<ApplicationUser>(new
                UserStore<ApplicationUser>(context));
                    
            if (userManager.FindByEmail("admin@coldmail.com" ) == null)
            {
                var user = new ApplicationUser {
                    Email = "admin@coldmail.com",
                    UserName = "admin@coldmail.com",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id,
                    "Admin");
            }
            if (userManager.FindByEmail("guest@coldmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "guest@coldmail.com",
                    UserName = "guest@coldmail.com",
                };
                var result = userManager.Create(user, "P@@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, 
                        "Guest");
            }
        }
    }
}
