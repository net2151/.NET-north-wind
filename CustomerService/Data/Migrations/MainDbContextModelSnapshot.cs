﻿// <auto-generated />
using System;
using CustomerService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerService.Data.Migrations
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

            modelBuilder.Entity("CustomerService.Domain.CustomerCustomerDemo", b =>
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

                    b.Property<Guid>("CustomerDemographicId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_demographic_id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_customer_customer_demo");

                    b.HasIndex("CustomerDemographicId")
                        .HasDatabaseName("ix_customer_customer_demo_customer_demographic_id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_customer_customer_demo_id");

                    b.ToTable("customer_customer_demo", "customer_service");
                });

            modelBuilder.Entity("CustomerService.Domain.CustomerDemographic", b =>
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

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_customer_demographics");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_customer_demographics_id");

                    b.ToTable("customer_demographics", "customer_service");
                });

            modelBuilder.Entity("CustomerService.Domain.CustomerInfo", b =>
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

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_customers_info");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_customers_info_id");

                    b.ToTable("customers_info", "customer_service");
                });

            modelBuilder.Entity("CustomerService.Domain.CustomerCustomerDemo", b =>
                {
                    b.HasOne("CustomerService.Domain.CustomerDemographic", null)
                        .WithMany("CustomerCustomerDemos")
                        .HasForeignKey("CustomerDemographicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_customer_demo_customer_demographics_customer_demog");
                });

            modelBuilder.Entity("CustomerService.Domain.CustomerDemographic", b =>
                {
                    b.Navigation("CustomerCustomerDemos");
                });
#pragma warning restore 612, 618
        }
    }
}
