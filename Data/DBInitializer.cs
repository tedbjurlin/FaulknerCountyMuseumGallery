using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GalleryContext context)
        {
            // Look for any Mediums.
            if (context.Mediums.Any())
            {
                return;   // DB has been seeded
            }

            var mediums = new Medium[]
            {
                new Medium{Description="Oil on Canvas"},
                new Medium{Description="Linoleum Print"},
                new Medium{Description="Woodcut Print"},
                new Medium{Description="Acrylic on Canvas"},
                new Medium{Description="Ceramic"},
                new Medium{Description="Mixed Media"},
                new Medium{Description="Plaster"},
                new Medium{Description="Film"}
            };

            context.Mediums.AddRange(mediums);
            context.SaveChanges();

            var Artists = new Artist[]
            {
                new Artist{Name="Edgar Degas"},
                new Artist{Name="Andy Warhol"},
                new Artist{Name="Sandro Botticelli"},
                new Artist{Name="Georgia O'Keeffe"},
                new Artist{Name="Vincent Van Gogh"},
                new Artist{Name="Mary Cassatt"}
            };

            context.Artists.AddRange(Artists);
            context.SaveChanges();

            var collections = new Collection[]
            {
                new Collection{Name="No Collection"}
            };

            context.Collections.AddRange(collections);
            context.SaveChanges();

            var artworks = new Artwork[]
            {
                new Artwork{MediumID=1,ArtistID=1,CollectionID=1,Title="The Dance Lesson",ImageLink="",Size=""},
                new Artwork{MediumID=1,ArtistID=4,CollectionID=1,Title="Lake George Reflection",ImageLink="",Size=""},
                new Artwork{MediumID=1,ArtistID=3,CollectionID=1,Title="The Birth of Venus",ImageLink="",Size=""},
                new Artwork{MediumID=2,ArtistID=2,CollectionID=1,Title="Crushed Campbell's Soup Can (Beef Noodle)",ImageLink="",Size=""},
                new Artwork{MediumID=2,ArtistID=5,CollectionID=1,Title="Self Portrait",ImageLink="",Size=""},
                new Artwork{MediumID=2,ArtistID=6,CollectionID=1,Title="Young Woman in a Black and Green Bonnet",ImageLink="",Size=""},
                new Artwork{MediumID=3,ArtistID=1,CollectionID=1,Title="Dancer",ImageLink="",Size=""},
                new Artwork{MediumID=4,ArtistID=1,CollectionID=1,Title="Dancers Resting",ImageLink="",Size=""},
                new Artwork{MediumID=4,ArtistID=2,CollectionID=1,Title="Skull",ImageLink="",Size=""},
                new Artwork{MediumID=5,ArtistID=3,CollectionID=1,Title="Portrait of a Young Man",ImageLink="",Size=""},
                new Artwork{MediumID=6,ArtistID=4,CollectionID=1,Title="Seaweed",ImageLink="",Size=""},
                new Artwork{MediumID=7,ArtistID=5,CollectionID=1,Title="Starry Night",ImageLink="",Size=""},
            };

            context.Artworks.AddRange(artworks);
            context.SaveChanges();
        }
    }
}