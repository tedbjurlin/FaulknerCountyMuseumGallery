namespace FaulknerCountyMuseumGallery.Models
{
    public class Medium
    {
        public int ID { get; set; }
        public string Descripion { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}