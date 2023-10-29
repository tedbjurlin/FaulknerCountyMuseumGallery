using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class EditModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public EditModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artwork Artwork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artworks == null)
            {
                return NotFound();
            }

            var artwork =  await _context.Artworks.FirstOrDefaultAsync(m => m.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            Artwork = artwork;
           ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name");
           ViewData["MediumID"] = new SelectList(_context.Mediums, "ID", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Artwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtworkExists(Artwork.ArtworkID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtworkExists(int id)
        {
          return _context.Artworks.Any(e => e.ArtworkID == id);
        }
    }
}
