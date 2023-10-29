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

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Artist> Artists { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Artist> artistsIQ = from a in _context.Artists select a;

            switch (sortOrder)
            {
                case "name_desc":
                    artistsIQ = artistsIQ.OrderByDescending(a => a.Name);
                    break;
                default:
                    artistsIQ = artistsIQ.OrderBy(a => a.Name);
                    break;
            }

            Artists = await artistsIQ.AsNoTracking().ToListAsync();
        }
    }
}
