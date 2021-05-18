using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace E_Commerce_API.Models
{
    public partial class Ecommerce : DbContext
    {
        public Ecommerce()
            : base("name=Ecommerce3")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Order_Id);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.StoretId);
        }
    }
}
