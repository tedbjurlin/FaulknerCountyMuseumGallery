using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaulknerCountyMuseumGallery.Models
{
    public class Medium
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}