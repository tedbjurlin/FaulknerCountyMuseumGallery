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

            var artworks = new Artwork[]
            {
                new Artwork{MediumID=1,ArtistID=1,Title="The Dance Lesson",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHchAPRorufLZrju7Vwiw541hnDyLUgXigPKrTj0eebQlkt6nhVRzo8GsOmwSx2nMVpvn0cPyTUh7Q5c5S7JF_E__fRG6HADjh29vDgz-v8f_OfOUrI=w2400",Size=""},
                new Artwork{MediumID=1,ArtistID=4,Title="Lake George Reflection",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHc99zYn7LX1H9S_HB15KRmkcNCSIaWgdtGoWE3qNKgmy0n8s4fzoUOH2QXMzhGQaVCgRVEtapSXDWLFoghCzMX30zrhSassGjwAjyTwUj9F8Lo6aiM=w2400",Size=""},
                new Artwork{MediumID=1,ArtistID=3,Title="The Birth of Venus",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHcPDjtT5rgcAQkwo4TJF28uwrqaWGMNePaY0Jqp71yRLMA0FhclSsRtPHElw2tIuSiPo7mZOKFSoLn75VJR3JwBHwdNnBjkJutVmYjEeCJbfnf9oOY=w2400",Size=""},
                new Artwork{MediumID=2,ArtistID=2,Title="Crushed Campbell's Soup Can (Beef Noodle)",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHe5_W7N6b6HizXxcqm-UZAHdyK1h2FKqgqjDxrGlfam4iEMVCVb-Mt8UAwza_4eI6rCYTb4yaM0U5lsi4LFIxfu1sB6oVYJlz-F6UrjZOrRxAnQE9s=w2400",Size=""},
                new Artwork{MediumID=2,ArtistID=5,Title="Self Portrait",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHeKmqZ6GoVMYMQJK8QD6uYf1rSU-XNwx1vD69CuKf8MvMKtg08_MsU6YWeDOe7_gM5PSZk4-XNT4iqoRTkYHRYqBGkkx_i3VwAXMQwXAXR-ydggJyw=w2400",Size=""},
                new Artwork{MediumID=2,ArtistID=6,Title="Young Woman in a Black and Green Bonnet",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHew7hj0QlHzftnT-2SjAhziTIhP3er9O_O4gBeNA9fLbmJpfDYLHMzutypkbx0uLX-xjgPikZdQHPYX8pLC1UG4Kb4Vj1yTm0KfxvB9F45bcC9pndo=w2400",Size=""},
                new Artwork{MediumID=3,ArtistID=1,Title="Dancer",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHfqW7cFQeFmduQJmlOXWCj7zpYUsdoUeNKsgZCIxZSfinITzEOshn71Ngc737T7rrM7TKwSudJCR9ycpo0neQmDC6TmEcy5YSFmHBionXHAAlalXgA=w2400",Size=""},
                new Artwork{MediumID=4,ArtistID=1,Title="Dancers Resting",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHfyFAGrdiQNbgaY0eczm8lo86cFmZsWQujEcb_VSufG1M_ouD0jHsvxxmAjGxcoeqccnHEJyIzy3je3TuUEIp6mt-8VD26SI9imcYfTWBpOW-mgLw8=w2400",Size=""},
                new Artwork{MediumID=4,ArtistID=2,Title="Skull",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHd_MUVIaYmP0w64n4uVYixIiIhvx6QNPsuS09Cg4hHQHbx4-ESBIrfZt6s0HVmSTL9YvD84pLZCImWS3jQ3OvY0kOmB5gmHtEX9qjQ1JQJ4t9ZkLY8=w2400",Size=""},
                new Artwork{MediumID=5,ArtistID=3,Title="Portrait of a Young Man",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHdEXof-XK7KB3mta6lgDOV30xwTOlOCUh6fMHHAkq7mjQ7kOmq0DGACYtn58JjaGG3l7SWfDJeLZXmlUp8D4g1xH1BL0OqqfccEmoc7bstaLxw0-vQ=w2400",Size=""},
                new Artwork{MediumID=6,ArtistID=4,Title="Seaweed",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHeDPu0Ye8vpTuo8g7CH1qd_zeuaOdPzfzg2nZ--aizqUlzVEeKx77aDyMdt_MLChOdnePB2YdPna4g77HVggXHgWoRvB3WMZdBun3oS1uOBxyTeyTU=w2400",Size=""},
                new Artwork{MediumID=7,ArtistID=5,Title="Starry Night",ImageLink="https://lh3.googleusercontent.com/pw/ADCreHcZ-WqfurdOo1PMCmapdo5MWK4Pdf8vMF9tJ_IfrWmpLvpcbLaOWnW7ByKxpFYYDygR2lEzxgRG3cn3m_iFQTtde9vRS10sNiKXV1mdSqbx5z1dPl4=w2400",Size=""},
            };

            context.Artworks.AddRange(artworks);
            context.SaveChanges();
        }
    }
}