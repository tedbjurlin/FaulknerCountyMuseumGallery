using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Artworks
{
    public class CreateModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public CreateModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name");
        ViewData["MediumID"] = new SelectList(_context.Mediums, "ID", "Description");
            return Page();
        }

        [BindProperty]
        public Artwork Artwork { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artworks.Add(Artwork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
