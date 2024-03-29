﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SDL;

namespace SDL.Migrations
{
    [DbContext(typeof(ChocolatefactoryContext))]
    [Migration("20210521220439_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MLineItemsMOrders", b =>
                {
                    b.Property<int>("lineItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("ordersId")
                        .HasColumnType("integer");

                    b.HasKey("lineItemsId", "ordersId");

                    b.HasIndex("ordersId");

                    b.ToTable("MLineItemsMOrders");
                });

            modelBuilder.Entity("Models.MCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.MInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ProductId")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Models.MLineItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<string>("ProId")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("productBarcode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("productBarcode");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("Models.MLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("MInventoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("MLineItemsId")
                        .HasColumnType("integer");

                    b.Property<string>("MProductBarcode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ProId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MInventoryId");

                    b.HasIndex("MLineItemsId");

                    b.HasIndex("MProductBarcode");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Models.MOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustID")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<int?>("customerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("storeFrontsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.HasIndex("storeFrontsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.MProduct", b =>
                {
                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<int?>("MInventoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("MLineItemsId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Barcode");

                    b.HasIndex("MInventoryId");

                    b.HasIndex("MLineItemsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MLineItemsMOrders", b =>
                {
                    b.HasOne("Models.MLineItems", null)
                        .WithMany()
                        .HasForeignKey("lineItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MOrders", null)
                        .WithMany()
                        .HasForeignKey("ordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.MLineItems", b =>
                {
                    b.HasOne("Models.MProduct", "product")
                        .WithMany()
                        .HasForeignKey("productBarcode");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Models.MLocation", b =>
                {
                    b.HasOne("Models.MInventory", null)
                        .WithMany("storeFront")
                        .HasForeignKey("MInventoryId");

                    b.HasOne("Models.MLineItems", null)
                        .WithMany("locations")
                        .HasForeignKey("MLineItemsId");

                    b.HasOne("Models.MProduct", null)
                        .WithMany("MLocation")
                        .HasForeignKey("MProductBarcode");
                });

            modelBuilder.Entity("Models.MOrders", b =>
                {
                    b.HasOne("Models.MCustomer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId");

                    b.HasOne("Models.MLocation", "storeFronts")
                        .WithMany()
                        .HasForeignKey("storeFrontsId");

                    b.Navigation("customer");

                    b.Navigation("storeFronts");
                });

            modelBuilder.Entity("Models.MProduct", b =>
                {
                    b.HasOne("Models.MInventory", null)
                        .WithMany("products")
                        .HasForeignKey("MInventoryId");

                    b.HasOne("Models.MLineItems", null)
                        .WithMany("products")
                        .HasForeignKey("MLineItemsId");
                });

            modelBuilder.Entity("Models.MInventory", b =>
                {
                    b.Navigation("products");

                    b.Navigation("storeFront");
                });

            modelBuilder.Entity("Models.MLineItems", b =>
                {
                    b.Navigation("locations");

                    b.Navigation("products");
                });

            modelBuilder.Entity("Models.MProduct", b =>
                {
                    b.Navigation("MLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
