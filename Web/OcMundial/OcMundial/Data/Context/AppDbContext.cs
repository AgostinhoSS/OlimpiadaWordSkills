﻿using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;
using OcMundial.Data.Models;

namespace BlazorApp1.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Items> Items { get; set; }

        public DbSet<ItemPicture> ItemPictures { get; set; }

        public DbSet<ItemAmenities> ItemAmenities { get; set; }

        public DbSet<ItemPrices> ItemPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ComX;User ID=sa;Password=sql2017;TrustServerCertificate=true");
        }
    }
}
