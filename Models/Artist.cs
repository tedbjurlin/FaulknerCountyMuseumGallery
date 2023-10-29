namespace FaulknerCountyMuseumGallery.Models
{

    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}