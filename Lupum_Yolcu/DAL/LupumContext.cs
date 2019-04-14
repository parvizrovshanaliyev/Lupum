using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Lupum_Yolcu.Models;

namespace Lupum_Yolcu.DAL
{
    public class LupumContext:DbContext
    {
        public LupumContext():base("LupumStr")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductNetworkPrice> ProductNetworkPrices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Models.Type> Types { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}