using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using Microsoft.AspNetCore.Authorization;

namespace FaulknerCountyMuseumGallery.Pages.Mediums
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public CreateModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Medium Medium { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string? prevPage, int? collectionID,
            int? artistID, string title = "", string accessionNumber = "",
            string imageURL = "", string size = "", string status = "", string donor = "")
        {
            var emptyMedium = new Medium();

            if (await TryUpdateModelAsync<Medium>(
                emptyMedium,
                "medium",   // Prefix for form value.
                s => s.Description))
            {
                _context.Mediums.Add(emptyMedium);
                await _context.SaveChangesAsync();
                if (prevPage != null)
                {
                    return RedirectToPage(prevPage, new {title,
                    accessionNumber, imageURL, size, artistID, status, 
                    mediumID = emptyMedium.ID, donor, collectionID});
                }
                else
                {
                    return RedirectToPage("./Index");
                }
            }

            return Page();
        }
    }
}
