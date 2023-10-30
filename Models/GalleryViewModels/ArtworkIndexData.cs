using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaulknerCountyMuseumGallery.Models.GalleryViewModels
{
    public class ArtworkIndexData
    {
        public PaginatedList<Artwork> Artworks { get; set; }
        public Artist Artist { get; set; }
        public Medium Medium { get; set; }
    }
}