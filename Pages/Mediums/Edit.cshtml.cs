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

namespace FaulknerCountyMuseumGallery.Pages.Mediums
{
    public class EditModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public EditModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medium Medium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mediums == null)
            {
                return NotFound();
            }

            var medium =  await _context.Mediums.FindAsync(id);

            if (medium == null)
            {
                return NotFound();
            }
            Medium = medium;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var mediumToUpdate = await _context.Mediums.FindAsync(id);

            if (mediumToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Medium>(
                mediumToUpdate,
                "medium",
                s => s.Description))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool MediumExists(int id)
        {
          return _context.Mediums.Any(e => e.ID == id);
        }
    }
}
