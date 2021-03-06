using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RealEstate.API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 642, DateTimeKind.Local).AddTicks(7817),
                            Description = "V??lkomna till denna vackra l??genhet i centrala Stockholm med tv?? sovrum och stort k??k",
                            PropertyId = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            PropertyType = 1,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Vacker tv??a p?? Sveav??gen"
                        },
                        new
                        {
                            Id = new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(1140),
                            Description = "Njut av kv??llssolen p?? den fina balkongen i denna fina och ytsmarta l??genhet i hj??rtat av G??teborg",
                            PropertyId = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            PropertyType = 3,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Rymlig etta mitt i G??teborg"
                        },
                        new
                        {
                            Id = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            CanBeRented = true,
                            CanBeSold = false,
                            Contact = "0888-888-888",
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(1174),
                            Description = "Med v??ra modernt ljudisolerade f??nster h??r du inget av det blodiga g??ngkring som just nu sk??rdar liv i Malm??s innerstad",
                            PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                            PropertyType = 2,
                            RentingPrice = 1000,
                            SellingPrice = 10000000,
                            Title = "Skaplig trea i Malm?? centrum"
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
                        
                    b.HasKey("Id");

                    b.HasIndex("AdvertismentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                            AdvertismentId = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            Content = "D??lig utsikt!!",
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(2319)
                        },
                        new
                        {
                            Id = new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                            AdvertismentId = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            Content = "V??ldigt fint l??ge.",
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(3450)
                        },
                        new
                        {
                            Id = new Guid("3ed2d9cc-295d-4e46-a7fb-6d698cd36975"),
                            AdvertismentId = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                            Content = "Bra pris.",
                            CreatedOn = new DateTime(2021, 6, 16, 11, 56, 11, 645, DateTimeKind.Local).AddTicks(3466)
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
                            Address = "Sveav??gen 12, Stockholm",
                            YearOfConstruction = 1978
                        },
                        new
                        {
                            Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                            Address = "Drottninggatan 4, G??teborg",
                            YearOfConstruction = 2002
                        },
                        new
                        {
                            Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                            Address = "Stora Torg 9, Malm??",
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

                    b.Navigation("Advertisment");
                });

            modelBuilder.Entity("Entities.Models.Advertisment", b =>
                {
                    b.Navigation("Comments");
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
