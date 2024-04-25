using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Food_Delivery_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_API.Data;

public class FoodDeliveryContext : DbContext
{
    public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options) 
        :base(options)
    {
        
    }

    DbSet<User> Users { get; set; }
    DbSet<Restaurant> Restaurants { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<Menu> Menus { get; set; }
    DbSet<MenuItem> MenuItems { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<RatingRestaurant> RatingRestaurants { get; set; }
    DbSet<Payment> Payments { get; set; }
    DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
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
    }
}