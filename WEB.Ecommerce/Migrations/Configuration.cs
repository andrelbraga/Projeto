using Microsoft.AspNet.Identity;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WEB.Ecommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WEB.Ecommerce.Models.ApplicationDbContext context)
        {
            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(
            u => u.UserName,
            new ApplicationUser
            {
                UserName = "aa@mvc.br",
                PasswordHash = hasher.HashPassword("Pass@word1"),
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser
            {
                UserName = "admin@mvc.br",
                PasswordHash = hasher.HashPassword("Pass@word1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
