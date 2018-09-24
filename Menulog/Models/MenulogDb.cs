using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Menulog.Models
{
    public class MenulogDb: DbContext
    {
        public MenulogDb():base("name=DefaultConnection")
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}