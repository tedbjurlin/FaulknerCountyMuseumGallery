using System.ComponentModel.DataAnnotations;

namespace FaulknerCountyMuseumGallery.Models
{
    public class Collection
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}