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

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class EditModel : ArtistMediumCollectionPageModel
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
                .Include(a => a.Medium)
                .Include(a => a.Collection)
                .FirstOrDefaultAsync(m => m.ArtworkID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            Artwork = artwork;
            PopulateArtistsDropDownList(_context, Artwork.ArtistID);
            PopulateMediumsDropDownList(_context, Artwork.MediumID);
            PopulateCollectionsDropDownList(_context, Artwork.CollectionID);
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
                s => s.CollectionID,
                s => s.Title,
                s => s.AccessionNumber,
                s => s.ImageLink,
                s => s.Size,
                s => s.Status,
                s => s.Donor))
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
