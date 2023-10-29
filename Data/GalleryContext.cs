using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext (DbContextOptions<GalleryContext> options)
            : base(options)
        {
        }

        public DbSet<Medium> Mediums { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medium>().ToTable("Medium");
            modelBuilder.Entity<Artwork>().ToTable("Artwork");
            modelBuilder.Entity<Artist>().ToTable("Artist");
        }
    }
}
