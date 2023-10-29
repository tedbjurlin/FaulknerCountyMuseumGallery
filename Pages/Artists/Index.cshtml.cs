using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;

namespace FaulknerCountyMuseumGallery.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;

        public IndexModel(FaulknerCountyMuseumGallery.Data.GalleryContext context)
        {
            _context = context;
        }

        public IList<Artist> Artists { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Artists != null)
            {
                Artists = await _context.Artists.ToListAsync();
            }
        }
    }
}
