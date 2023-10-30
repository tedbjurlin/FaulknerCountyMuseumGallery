using System.ComponentModel.DataAnnotations;

namespace FaulknerCountyMuseumGallery.Models
{
    public class Artwork
    {
        public int ArtworkID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageLink { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Display(Name = "Medium")]
        public int MediumID { get; set; }
        [Required]
        [Display(Name = "Artist")]
        public int ArtistID { get; set; }

        public Medium Medium { get; set; }
        public Artist Artist { get; set; }
    }
}