using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using Microsoft.AspNetCore.Authorization;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public DetailsModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

      public Artwork Artwork { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artworks == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks
                .AsNoTracking()
                .Include(a => a.Artist)
                .Include(a => a.Medium)
                .Include(a => a.Collection)
                .FirstOrDefaultAsync(m => m.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            else 
            {
                Artwork = artwork;
            }
            return Page();
        }
    }
}
