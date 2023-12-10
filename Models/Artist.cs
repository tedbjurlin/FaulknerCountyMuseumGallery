using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaulknerCountyMuseumGallery.Models
{

    public class Artist
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Name { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}