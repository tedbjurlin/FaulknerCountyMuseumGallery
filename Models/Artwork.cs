namespace FaulknerCountyMuseumGallery.Models
{
    public class Artwork
    {
        public int ArtworkID { get; set; }
        public int MediumID { get; set; }
        public int ArtistID { get; set; }
        public string ImageLink { get; set; }
        public string Size { get; set; }

        public Medium Medium { get; set; }
        public Artist Artist { get; set; }
    }
}