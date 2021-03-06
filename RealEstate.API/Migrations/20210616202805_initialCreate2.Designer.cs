// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RealEstate.API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210616202805_initialCreate2")]
    partial class initialCreate2
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
                            Id = new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 436, DateTimeKind.Local).AddTicks(8167),
                            Description = "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök",
                            PropertyId = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            PropertyType = 1,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Vacker tvåa på Sveavägen"
                        },
                        new
                        {
                            Id = new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(1341),
                            Description = "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg",
                            PropertyId = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            PropertyType = 3,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Rymlig etta mitt i Göteborg"
                        },
                        new
                        {
                            Id = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(1518),
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

                    b.Property<Guid>("AdvertismentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertismentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c30141ec-acfa-4a5f-8869-c1fedcc410be"),
                            AdvertismentId = new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                            Content = "Dålig utsikt!!",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(2653)
                        },
                        new
                        {
                            Id = new Guid("b2aa2881-9021-4d91-88ff-8f452dccc105"),
                            AdvertismentId = new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                            Content = "Väldigt fint läge.",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(3770)
                        },
                        new
                        {
                            Id = new Guid("acbcb3d5-64e2-420b-93c7-99d3435377f9"),
                            AdvertismentId = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            Content = "Bra pris.",
                            CreatedOn = new DateTime(2021, 6, 16, 22, 28, 5, 439, DateTimeKind.Local).AddTicks(3785)
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

                    b.Property<string>("UserToWriteAboutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("WrittenByUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserToWriteAboutId");

                    b.HasIndex("WrittenByUserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

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
                    b.HasOne("Entities.Models.Advertisment", "Advertisment")
                        .WithMany("Comments")
                        .HasForeignKey("AdvertismentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Advertisment");
                });

            modelBuilder.Entity("Entities.Models.Rating", b =>
                {
                    b.HasOne("Entities.Models.User", "UserToWriteAbout")
                        .WithMany("MyRatings")
                        .HasForeignKey("UserToWriteAboutId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entities.Models.User", "WrittenByUser")
                        .WithMany("RatingsDoneByMe")
                        .HasForeignKey("WrittenByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserToWriteAbout");

                    b.Navigation("WrittenByUser");
                });

            modelBuilder.Entity("Entities.Models.Advertisment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Entities.Models.Property", b =>
                {
                    b.Navigation("Advertisment");
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
