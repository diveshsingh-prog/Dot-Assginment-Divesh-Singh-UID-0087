using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RestaurantManagement.Models.Entity;
using System.Data;
using System.Data.SqlTypes;

namespace RestaurantManagement.Data
{
    public class Applicationdbcontext : DbContext
    {
        public Applicationdbcontext() : base("name=DefaultConnection")
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwner { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         

        }
    }
}