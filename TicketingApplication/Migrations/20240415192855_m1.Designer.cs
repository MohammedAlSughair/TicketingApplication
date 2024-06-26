﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using  TicketingApplication.Entities;

#nullable disable

namespace  TicketingApplication.Migrations
{
    [DbContext(typeof(TicketingApplicationDBContext))]
    [Migration("20240415192855_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity(" TicketingApplication.Entities.Areas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CityId = 1,
                            Name = "Center"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Cities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CountryId = 1,
                            Name = "Amman"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Countries", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Jordan"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.CustomerBranch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerBranch");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CustomerId = 1,
                            Description = "Arab Bank"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.CustomerLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AreaId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerLocation");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AreaId = 1,
                            BranchId = 1,
                            CityId = 1,
                            CountryId = 1,
                            CustomerId = 1
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Arab Bank"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Tags", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("TagNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CustomerID = 1,
                            TagNumber = 1
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Technicians", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Technician1"
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.TicketTransaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewStatus")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OldStatus")
                        .HasColumnType("int");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TicketID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("TicketTransaction");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Tickets", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SolvedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TicketDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TagID");

                    b.HasIndex("TechnicianID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Admin1",
                            Password = "Admin123",
                            UserType = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "Technician1",
                            Password = "Technician123",
                            UserType = 2
                        });
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Areas", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Cities", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Cities", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.CustomerBranch", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.CustomerLocation", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Areas", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.CustomerBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Cities", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Branch");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Tags", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.TicketTransaction", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.Tickets", "Ticket")
                        .WithOne("TicketTransaction")
                        .HasForeignKey(" TicketingApplication.Entities.TicketTransaction", "TicketID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Tickets", b =>
                {
                    b.HasOne(" TicketingApplication.Entities.CustomerBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Tags", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne(" TicketingApplication.Entities.Technicians", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Customer");

                    b.Navigation("Tag");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity(" TicketingApplication.Entities.Tickets", b =>
                {
                    b.Navigation("TicketTransaction")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
