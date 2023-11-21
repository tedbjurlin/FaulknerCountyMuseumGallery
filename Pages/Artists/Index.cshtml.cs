using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using Microsoft.AspNetCore.Authorization;

namespace FaulknerCountyMuseumGallery.Pages.Artists
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GalleryContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(GalleryContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Artist> Artists { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Artist> artistsIQ = from a in _context.Artists select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                artistsIQ = artistsIQ.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    artistsIQ = artistsIQ.OrderByDescending(a => a.Name);
                    break;
                default:
                    artistsIQ = artistsIQ.OrderBy(a => a.Name);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Artists = await PaginatedList<Artist>.CreateAsync(
                artistsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
