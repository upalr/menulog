namespace Menulog.Migrations
{
    using Menulog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Menulog.Models.MenulogDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Menulog.Models.MenulogDb";
        }

        protected override void Seed(Menulog.Models.MenulogDb context)
        {
            //TUT: Everytime it goes to update (migration update: you typically run a database update when you want to mygrate the schema) the database, it's going to invoke this seed method
            //TUT: Everytime i update (migration update: you typically run a database update when you want to mygrate the schema) the database, this seed method will run


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Oporto", City = "Melbourne", Country = "Australia" },
                new Restaurant { Name = "Hungry Jacks", City = "Melbourne", Country = "Australia" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Sydney",
                    Country = "Australia",
                    Reviews = new List<RestaurantReview> {
                        new RestaurantReview{ Rating=9,Body="Great Food!", ReviewerName="Upal Roy" }
                    }
                });
        }
    }
}
