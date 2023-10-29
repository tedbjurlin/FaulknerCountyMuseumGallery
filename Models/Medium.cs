namespace FaulknerCountyMuseumGallery.Models
{
    public class Medium
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}