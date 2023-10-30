using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using FaulknerCountyMuseumGallery.Models.GalleryViewModels;  // Add VM

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class IndexModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public IndexModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public ArtworkIndexData ArtworkData { get; set; }
        public int ArtworkID { get; set; }

        public async Task OnGetAsync(int? id, int? mediumID)
        {
            ArtworkData = new ArtworkIndexData();
            ArtworkData.Artworks = await _context.Artworks
                .Include(i => i.Artist)
                .Include(i => i.Medium)
                .ToListAsync();
            
            if (id != null)
            {
                ArtworkID = id.Value;
                Artwork artwork = ArtworkData.Artworks
                    .Where(i => i.ArtworkID == id.Value).Single();
                ArtworkData.Artist = artwork.Artist;
                ArtworkData.Medium = artwork.Medium;
            }
        }
    }
}
