﻿// <auto-generated />
using FaulknerCountyMuseumGallery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FaulknerCountyMuseumGallery.Migrations
{
    [DbContext(typeof(GalleryContext))]
    partial class GalleryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Artwork", b =>
                {
                    b.Property<int>("ArtworkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MediumID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ArtworkID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("MediumID");

                    b.ToTable("Artwork", (string)null);
                });

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Medium", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Medium", (string)null);
                });

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Artwork", b =>
                {
                    b.HasOne("FaulknerCountyMuseumGallery.Models.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FaulknerCountyMuseumGallery.Models.Medium", "Medium")
                        .WithMany("Artworks")
                        .HasForeignKey("MediumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Medium");
                });

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("FaulknerCountyMuseumGallery.Models.Medium", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
