using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Mediums
{
    public class DetailsModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public DetailsModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

      public Medium Medium { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mediums == null)
            {
                return NotFound();
            }

            var medium = await _context.Mediums.FirstOrDefaultAsync(m => m.ID == id);
            if (medium == null)
            {
                return NotFound();
            }
            else 
            {
                Medium = medium;
            }
            return Page();
        }
    }
}
