using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<LocalUser> LocalUsers { get; set; }
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Villa>().HasData(
            new Villa()
            {
                Id = 1,
                Name = "Royal Villa",
                Details = "Dummy Details",
                ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa1.jpg",
                Occupancy = 5,
                Rate = 200,
                Sqft = 550,
                Amenity = "",
                CreatedDate = DateTime.Now
            },
            new Villa
        {
            Id = 2,
            Name = "Cozy Cottage",
            Details = "Charming cottage surrounded by nature.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa2.jpg",
            Occupancy = 4,
            Rate = 150,
            Sqft = 450,
            Amenity = "Fireplace, Garden",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 3,
            Name = "Beachfront Bungalow",
            Details = "A villa with stunning ocean views.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa3.jpg",
            Occupancy = 6,
            Rate = 300,
            Sqft = 600,
            Amenity = "Beach Access, BBQ Area",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 4,
            Name = "Mountain Retreat",
            Details = "Peaceful retreat with breathtaking mountain views.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa4.jpg",
            Occupancy = 5,
            Rate = 250,
            Sqft = 520,
            Amenity = "Hiking Trails, Fireplace",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 5,
            Name = "Cityscape Loft",
            Details = "Modern villa located in the heart of the city.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa4.jpg",
            Occupancy = 3,
            Rate = 180,
            Sqft = 400,
            Amenity = "Rooftop Terrace, High-Speed Wi-Fi",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 6,
            Name = "Lakeside Lodge",
            Details = "Relaxing villa by the lake.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa5.jpg",
            Occupancy = 7,
            Rate = 280,
            Sqft = 700,
            Amenity = "Kayak Rental, Fishing Dock",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 7,
            Name = "Desert Oasis",
            Details = "Exotic villa in a desert landscape.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa4.jpg",
            Occupancy = 5,
            Rate = 220,
            Sqft = 550,
            Amenity = "Pool, Outdoor Lounge",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 8,
            Name = "Historic Manor",
            Details = "Elegant villa with historic charm.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa3.jpg",
            Occupancy = 8,
            Rate = 350,
            Sqft = 800,
            Amenity = "Library, Wine Cellar",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 9,
            Name = "Jungle Hideaway",
            Details = "Secluded villa surrounded by lush jungle.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa3.jpg",
            Occupancy = 4,
            Rate = 170,
            Sqft = 480,
            Amenity = "Outdoor Shower, Hammock",
            CreatedDate = DateTime.Now
        },
        new Villa
        {
            Id = 10,
            Name = "Snowy Chalet",
            Details = "Cozy villa with stunning snowy views.",
            ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa4.jpg",
            Occupancy = 6,
            Rate = 310,
            Sqft = 650,
            Amenity = "Ski-in/Ski-out, Hot Tub",
            CreatedDate = DateTime.Now
        });
    }
}