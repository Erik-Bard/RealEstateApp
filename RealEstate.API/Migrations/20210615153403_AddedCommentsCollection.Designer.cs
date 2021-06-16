﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RealEstate.API.Migrations.Repository
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210615153403_AddedCommentsCollection")]
    partial class AddedCommentsCollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Advertisment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeRented")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBeSold")
                        .HasColumnType("bit");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasMaxLength(1000)
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<int>("RentingPrice")
                        .HasColumnType("int");

                    b.Property<int>("SellingPrice")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Advertisments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 88, DateTimeKind.Local).AddTicks(7784),
                            Description = "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök",
                            PropertyId = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            PropertyType = 1,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Vacker tvåa på Sveavägen"
                        },
                        new
                        {
                            Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(515),
                            Description = "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg",
                            PropertyId = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            PropertyType = 3,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Rymlig etta mitt i Göteborg"
                        },
                        new
                        {
                            Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(549),
                            Description = "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad",
                            PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                            PropertyType = 2,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Skaplig trea i Malmö centrum"
                        });
                });

            modelBuilder.Entity("Entities.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                            Content = "Dålig utsikt!!",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(1367),
                            PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada")
                        },
                        new
                        {
                            Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            Content = "Väldigt fint läge.",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(2069),
                            PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada")
                        },
                        new
                        {
                            Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            Content = "Bra pris.",
                            CreatedOn = new DateTime(2021, 6, 15, 17, 34, 3, 91, DateTimeKind.Local).AddTicks(2083),
                            PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada")
                        });
                });

            modelBuilder.Entity("Entities.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfConstruction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                            Address = "Sveavägen 12, Stockholm",
                            YearOfConstruction = 1978
                        },
                        new
                        {
                            Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            Address = "Drottninggatan 4, Göteborg",
                            YearOfConstruction = 2002
                        },
                        new
                        {
                            Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            Address = "Stora Torg 9, Malmö",
                            YearOfConstruction = 1999
                        });
                });

            modelBuilder.Entity("Entities.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AboutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AverageRating")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalComments")
                        .HasColumnType("int");

                    b.Property<int>("TotalRealEstates")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.Advertisment", b =>
                {
                    b.HasOne("Entities.Models.Property", "Property")
                        .WithOne("Advertisment")
                        .HasForeignKey("Entities.Models.Advertisment", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("RealEstates")
                        .HasForeignKey("UserId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Entities.Models.Comment", b =>
                {
                    b.HasOne("Entities.Models.Property", "Property")
                        .WithMany("Comments")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Entities.Models.Rating", b =>
                {
                    b.HasOne("Entities.Models.User", "AboutUser")
                        .WithMany("MyRatings")
                        .HasForeignKey("AboutId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Models.User", "ByUser")
                        .WithMany("RatingsDoneByMe")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AboutUser");

                    b.Navigation("ByUser");
                });

            modelBuilder.Entity("Entities.Models.Property", b =>
                {
                    b.Navigation("Advertisment");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MyRatings");

                    b.Navigation("RatingsDoneByMe");

                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
