using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class DeleteModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public DeleteModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Artwork Artwork { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artworks == null)
            {
                return NotFound();
            }

            var artwork = await _context.Artworks.FirstOrDefaultAsync(m => m.ArtworkID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Artworks == null)
            {
                return NotFound();
            }
            var artwork = await _context.Artworks.FindAsync(id);

            if (artwork != null)
            {
                Artwork = artwork;
                _context.Artworks.Remove(Artwork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
