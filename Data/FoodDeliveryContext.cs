using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Food_Delivery_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Data;

public class FoodDeliveryContext : DbContext
{
    public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options) 
        :base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<RatingRestaurant> RatingRestaurants { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Restaurant)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<RatingRestaurant>()
            .HasOne(o => o.User)
            .WithMany(p => p.RatingRestaurants)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RatingRestaurant>()
            .HasOne(o => o.Restaurant)
            .WithMany(p => p.RatingRestaurants)
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>().Property(e=>e.UserId).ValueGeneratedOnAdd().HasColumnName("UserId");

        base.OnModelCreating(modelBuilder);
        List<IdentityRole> roles = new List<IdentityRole>(){
            new IdentityRole{
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole{
                Name = "User",
                NormalizedName = "USER"
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}