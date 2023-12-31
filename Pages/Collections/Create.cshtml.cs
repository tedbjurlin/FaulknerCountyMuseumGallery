using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Collections
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
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string? prevPage, int? artistID,
            int? mediumID, string title = "", string accessionNumber = "",
            string imageURL = "", string size = "", string status = "", string donor = "")
        {
            var emptyCollection = new Collection();

            if (await TryUpdateModelAsync<Collection>(
                emptyCollection,
                "collection",
                c => c.Name))
            {
                _context.Collections.Add(emptyCollection);
                await _context.SaveChangesAsync();
                if (prevPage != null)
                {
                    return RedirectToPage(prevPage, new {title,
                    accessionNumber, imageURL, size, mediumID, status, 
                    collectionID = emptyCollection.ID, donor, artistID});
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
