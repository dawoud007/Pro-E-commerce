﻿// <auto-generated />
using System;
using ElectronicsShop_service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ElectronicsShop_service.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 24, 19, 11, 29, 454, DateTimeKind.Local).AddTicks(3335));

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 24, 19, 11, 29, 456, DateTimeKind.Local).AddTicks(9046));

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 24, 19, 11, 29, 457, DateTimeKind.Local).AddTicks(1039));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.CustomerProduct", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.HasKey("CustomerId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerProduct");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Brand")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CartId1")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 24, 19, 11, 29, 459, DateTimeKind.Local).AddTicks(906));

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Rating")
                        .HasColumnType("float");

                    b.Property<Guid?>("categoryID")
                        .HasColumnType("char(36)");

                    b.Property<int?>("code")
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .HasColumnType("longtext");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("image")
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CartId1")
                        .IsUnique();

                    b.HasIndex("categoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Cart", b =>
                {
                    b.HasOne("ElectronicsShop_service.Models.Customer", "Customer")
                        .WithOne("Cart")
                        .HasForeignKey("ElectronicsShop_service.Models.Cart", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.CustomerProduct", b =>
                {
                    b.HasOne("ElectronicsShop_service.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicsShop_service.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Product", b =>
                {
                    b.HasOne("ElectronicsShop_service.Models.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("ElectronicsShop_service.Models.Cart", null)
                        .WithOne("Product")
                        .HasForeignKey("ElectronicsShop_service.Models.Product", "CartId1");

                    b.HasOne("ElectronicsShop_service.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cart");

                    b.Navigation("category");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Cart", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Customer", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
