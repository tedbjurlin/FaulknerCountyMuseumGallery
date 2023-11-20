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

namespace FaulknerCountyMuseumGallery.Pages.Mediums
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(FaulknerCountyMuseumGallery.Data.GalleryContext context,
            IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string DescriptionSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Medium> Mediums { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DescriptionSort = String.IsNullOrEmpty(sortOrder) ? "description_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Medium> mediumsIQ = from m in _context.Mediums select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                mediumsIQ = mediumsIQ.Where(m => m.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "description_desc":
                    mediumsIQ = mediumsIQ.OrderByDescending(m => m.Description);
                    break;
                default:
                    mediumsIQ = mediumsIQ.OrderBy(m => m.Description);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Mediums = await PaginatedList<Medium>.CreateAsync(
                mediumsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
