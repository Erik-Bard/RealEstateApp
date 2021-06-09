using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.EnumHelpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.API.Extensions
{
    public static class ModelBuilderHelper
    {

        //Seed Data
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                    YearOfConstruction = 1978,
                    Address = "Sveavägen 12, Stockholm"
                },
                new Property
                {
                    Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                    YearOfConstruction = 2002,
                    Address = "Drottninggatan 4, Göteborg"
                },
                new Property
                {
                    Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                    YearOfConstruction = 1999,
                    Address = "Stora Torg 9, Malmö"
                });

            modelBuilder.Entity<Advertisment>().HasData(
                new Advertisment
                {
                    Id = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                    Title = "Vacker tvåa på Sveavägen",
                    Description = "Välkomna till denna vackra lägenhet i centrala Stockholm med två sovrum och stort kök",
                    CreatedOn = DateTime.Now,
                    SellingPrice = 10000000,
                    RentingPrice = 1000,
                    Contact = "0888-888-888",
                    PropertyType = PropertyType.Apartment,
                    CanBeRented = true,
                    CanBeSold = false,
                    PropertyId = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),

                },
                new Advertisment
                {
                    Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                    Title = "Rymlig etta mitt i Göteborg",
                    Description = "Njut av kvällssolen på den fina balkongen i denna fina och ytsmarta lägenhet i hjärtat av Göteborg",
                    CreatedOn = DateTime.Now,
                    SellingPrice = 10000000,
                    RentingPrice = 1000,
                    Contact = "0888-888-888",
                    PropertyType = PropertyType.Warehouse,
                    CanBeRented = true,
                    CanBeSold = false,
                    PropertyId = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                },
                new Advertisment
                {
                    Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                    Title = "Skaplig trea i Malmö centrum",
                    Description = "Med våra modernt ljudisolerade fönster hör du inget av det blodiga gängkring som just nu skördar liv i Malmös innerstad",
                    CreatedOn = DateTime.Now,
                    SellingPrice = 10000000,
                    RentingPrice = 1000,
                    Contact = "0888-888-888",
                    PropertyType = PropertyType.House,
                    CanBeRented = true,
                    CanBeSold = false,
                    PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada")
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = new Guid("7e5d5379-9f9e-4bf6-9744-7623008c998d"),
                    CreatedOn = DateTime.Now,
                    PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                    Content = "Dålig utsikt!!",
                },
                new Comment
                {
                    Id = new Guid("78591990-5d89-4aa5-aaed-345505bdd1c3"),
                    CreatedOn = DateTime.Now,
                    PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                    Content = "Väldigt fint läge.",
                },
                new Comment
                {
                    Id = new Guid("7e6d5379-9f9e-4bf6-9744-7623008c943e"),
                    CreatedOn = DateTime.Now,
                    PropertyId = new Guid("e277bec0-2f9d-40c6-9433-f7c6ecfa7ada"),
                    Content = "Bra pris.",
                });

        }
    }
}

