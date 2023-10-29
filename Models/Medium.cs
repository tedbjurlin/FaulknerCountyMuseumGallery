using System.ComponentModel.DataAnnotations;

namespace FaulknerCountyMuseumGallery.Models
{
    public class Medium
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}