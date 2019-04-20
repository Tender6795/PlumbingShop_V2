namespace PlumbingShop_V2.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyContext : DbContext
    {

        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<ShowerCubicle> ShowerCubicles { get; set; }
        public DbSet<Bath> Bathes { get; set; }
        public DbSet<Toilet> Toilets { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }

}