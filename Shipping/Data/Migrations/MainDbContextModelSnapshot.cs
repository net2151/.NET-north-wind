﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shipping.Data;

#nullable disable

namespace Shipping.Data.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shipping.Domain.ShipperInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<Guid>("ShipperId")
                        .HasColumnType("uuid")
                        .HasColumnName("shipper_id");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_shippers_info");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_shippers_info_id");

                    b.ToTable("shippers_info", "shipping");
                });

            modelBuilder.Entity("Shipping.Domain.ShippingOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()");

                    b.Property<float?>("Freight")
                        .HasColumnType("real")
                        .HasColumnName("freight");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("text")
                        .HasColumnName("ship_address");

                    b.Property<string>("ShipCity")
                        .HasColumnType("text")
                        .HasColumnName("ship_city");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("text")
                        .HasColumnName("ship_country");

                    b.Property<string>("ShipName")
                        .HasColumnType("text")
                        .HasColumnName("ship_name");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("text")
                        .HasColumnName("ship_postal_code");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("text")
                        .HasColumnName("ship_region");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("shipped_date");

                    b.Property<Guid?>("ShipperInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("shipper_info_id");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_shipping_orders");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_shipping_orders_id");

                    b.HasIndex("ShipperInfoId")
                        .HasDatabaseName("ix_shipping_orders_shipper_info_id");

                    b.ToTable("shipping_orders", "shipping");
                });

            modelBuilder.Entity("Shipping.Domain.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Abbr")
                        .HasColumnType("text")
                        .HasColumnName("abbr");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Region")
                        .HasColumnType("text")
                        .HasColumnName("region");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_states");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_states_id");

                    b.ToTable("states", "shipping");
                });

            modelBuilder.Entity("Shipping.Domain.ShippingOrder", b =>
                {
                    b.HasOne("Shipping.Domain.ShipperInfo", "ShipperInfo")
                        .WithMany()
                        .HasForeignKey("ShipperInfoId")
                        .HasConstraintName("fk_shipping_orders_shipper_info_shipper_info_temp_id");

                    b.Navigation("ShipperInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
