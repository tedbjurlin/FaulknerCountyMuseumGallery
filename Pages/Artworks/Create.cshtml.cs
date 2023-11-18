using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using FaulknerCountyMuseumGallery.Pages.Courses;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class CreateModel : ArtistMediumCollectionPageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public CreateModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateArtistsDropDownList(_context);
            PopulateMediumsDropDownList(_context);
            PopulateCollectionsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Artwork Artwork { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyArtwork = new Artwork();

            if (await TryUpdateModelAsync<Artwork>(
                emptyArtwork,
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
                _context.Artworks.Add(emptyArtwork);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        
            PopulateArtistsDropDownList(_context, emptyArtwork.ArtistID);
            PopulateMediumsDropDownList(_context, emptyArtwork.MediumID);
            PopulateCollectionsDropDownList(_context, emptyArtwork.CollectionID);
            return Page();

        }
    }
}
