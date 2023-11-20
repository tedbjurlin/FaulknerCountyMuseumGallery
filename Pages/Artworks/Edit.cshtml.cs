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
using FaulknerCountyMuseumGallery.Pages.Courses;
using Microsoft.AspNetCore.Authorization;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    [Authorize]
    public class EditModel : ArtistMediumPageModel
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

            var artwork =  await _context.Artworks
                .Include(a => a.Artist)
                .Include(a => a.Medium).FirstOrDefaultAsync(m => m.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            Artwork = artwork;
            PopulateArtistsDropDownList(_context, Artwork.ArtistID);
            PopulateMediumsDropDownList(_context, Artwork.MediumID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artworkToUpdate = await _context.Artworks.FindAsync(id);

            if (artworkToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Artwork>(
                artworkToUpdate,
                "artwork",
                s => s.ArtworkID,
                s => s.ArtistID,
                s => s.MediumID,
                s => s.Title,
                s => s.ImageLink,
                s => s.Size))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateArtistsDropDownList(_context, artworkToUpdate.ArtistID);
            PopulateMediumsDropDownList(_context, artworkToUpdate.MediumID);
            return Page();
        }
    }
}
