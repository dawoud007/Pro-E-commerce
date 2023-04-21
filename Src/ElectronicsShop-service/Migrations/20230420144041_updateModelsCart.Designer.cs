﻿// <auto-generated />
using System;
using ElectronicsShop_service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicsShop_service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230420144041_updateModelsCart")]
    partial class updateModelsCart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2023, 4, 20, 16, 40, 41, 114, DateTimeKind.Local).AddTicks(5596));

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

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
                        .HasDefaultValue(new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(6304));

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
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 20, 16, 40, 41, 119, DateTimeKind.Local).AddTicks(8835));

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
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
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CartId1")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 4, 20, 16, 40, 41, 126, DateTimeKind.Local).AddTicks(1979));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Rating")
                        .HasColumnType("float");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("code")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CartId1")
                        .IsUnique();

                    b.HasIndex("categoryId");

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
                    b.HasOne("ElectronicsShop_service.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("ElectronicsShop_service.Models.Cart", "Cart")
                        .WithOne("Product")
                        .HasForeignKey("ElectronicsShop_service.Models.Product", "CartId1");

                    b.HasOne("ElectronicsShop_service.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("category");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Cart", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ElectronicsShop_service.Models.Customer", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}