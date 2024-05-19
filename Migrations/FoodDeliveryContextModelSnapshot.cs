﻿// <auto-generated />
using System;
using Food_Delivery_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Food_Delivery_API.Migrations
{
    [DbContext(typeof(FoodDeliveryContext))]
    partial class FoodDeliveryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Food_Delivery_API.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.DeliveryDriver", b =>
                {
                    b.Property<int>("DeliveryDriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryDriverId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryDriverId");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("DeliveryDrivers");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.OrderMenuItem", b =>
                {
                    b.Property<int>("OrderMenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderMenuItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderMenuItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenuItem");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.RatingRestaurant", b =>
                {
                    b.Property<int>("RatingRestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingRestaurantId"));

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RatingRestaurantId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("RatingRestaurants");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4a7c3262-b48c-4f8b-8027-dede84cf48e7",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "50f32355-028c-4361-91ba-699d9b61c31d",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Food_Delivery_API.Models.DeliveryDriver", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Order", "Order")
                        .WithOne("DeliveryDriver")
                        .HasForeignKey("Food_Delivery_API.Models.DeliveryDriver", "OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Menu", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.MenuItem", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Order", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Food_Delivery_API.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.OrderMenuItem", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Food_Delivery_API.Models.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Payment", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Food_Delivery_API.Models.Payment", "OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.RatingRestaurant", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.Restaurant", "Restaurant")
                        .WithMany("RatingRestaurants")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Food_Delivery_API.Models.User", "User")
                        .WithMany("RatingRestaurants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Restaurant", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.User", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Food_Delivery_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Food_Delivery_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Food_Delivery_API.Models.City", b =>
                {
                    b.Navigation("Restaurants");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Menu", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.MenuItem", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Order", b =>
                {
                    b.Navigation("DeliveryDriver")
                        .IsRequired();

                    b.Navigation("OrderMenuItems");

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("Food_Delivery_API.Models.Restaurant", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Orders");

                    b.Navigation("RatingRestaurants");
                });

            modelBuilder.Entity("Food_Delivery_API.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("RatingRestaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
