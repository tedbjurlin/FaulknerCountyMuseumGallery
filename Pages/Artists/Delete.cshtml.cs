using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using Microsoft.Extensions.Logging;

namespace FaulknerCountyMuseumGallery.Pages.Artists
{
    public class DeleteModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(FaulknerCountyMuseumGallery.Data.GalleryContext context,
                            ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Artist Artist { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            try
            {
                Artist = artist;
                _context.Artists.Remove(Artist);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true});
            }
        }
    }
}
