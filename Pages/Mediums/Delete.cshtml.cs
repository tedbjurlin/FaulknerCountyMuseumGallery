using FaulknerCountyMuseumGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FaulknerCountyMuseumGallery.Pages.Mediums
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
        public Medium Medium { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medium = await _context.Mediums
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Medium == null)
            {
                return NotFound();
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

            var medium = await _context.Mediums.FindAsync(id);

            if (medium == null)
            {
                return NotFound();
            }

            try
            {
                _context.Mediums.Remove(medium);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}