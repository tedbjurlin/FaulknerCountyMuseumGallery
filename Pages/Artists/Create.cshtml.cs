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

namespace FaulknerCountyMuseumGallery.Pages.Artists
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
        public Artist Artist { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string? prevPage, int? collectionID,
            int? mediumID, string title = "", string accessionNumber = "",
            string imageURL = "", string size = "", string status = "", string donor = "")
        {
            var emptyArtist = new Artist();

            if (await TryUpdateModelAsync<Artist>(
                emptyArtist,
                "artist",
                a => a.Name))
            {
                _context.Artists.Add(emptyArtist);
                await _context.SaveChangesAsync();
                if (prevPage != null)
                {
                    return RedirectToPage(prevPage, new {title,
                    accessionNumber, imageURL, size, mediumID, status, 
                    artistID = emptyArtist.ID, donor, collectionID});
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
