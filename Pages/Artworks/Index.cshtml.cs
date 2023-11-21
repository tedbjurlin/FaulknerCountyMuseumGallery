using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using FaulknerCountyMuseumGallery.Models.GalleryViewModels;
using Microsoft.AspNetCore.Authorization;  // Add VM

namespace FaulknerCountyMuseumGallery.Pages.Artworks
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

        public string TitleSort { get; set; }
        public string ArtistSort { get; set; }
        public string MediumSort { get; set; }
        public string CollectionSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public ArtworkIndexData ArtworkData { get; set; }
        public int ArtworkID { get; set; }

        public async Task OnGetAsync(int? id, int? mediumID, string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ArtistSort = sortOrder == "Artist" ? "artist_desc" : "Artist";
            MediumSort = sortOrder == "Medium" ? "medium_desc" : "Medium";
            CollectionSort = sortOrder == "Collection" ? "collection_desc" : "Collection";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Artwork> artworksIQ = from a in _context.Artworks select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                artworksIQ = artworksIQ.Where(a => a.Title.Contains(searchString)
                                        || a.Artist.Name.Contains(searchString)
                                        || a.Medium.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    artworksIQ = artworksIQ.OrderByDescending(a => a.Title);
                    break;
                case "Artist":
                    artworksIQ = artworksIQ.OrderBy(a => a.Artist.Name);
                    break;
                case "artist_desc":
                    artworksIQ = artworksIQ.OrderByDescending(a => a.Artist.Name);
                    break;
                case "Medium":
                    artworksIQ = artworksIQ.OrderBy(a => a.Medium.Description);
                    break;
                case "medium_desc":
                    artworksIQ = artworksIQ.OrderByDescending(a => a.Medium.Description);
                    break;
                case "Collection":
                    artworksIQ = artworksIQ.OrderBy(a => a.Collection.Name);
                    break;
                case "collection_desc":
                    artworksIQ = artworksIQ.OrderByDescending(a => a.Collection.Name);
                    break;
                default:
                    artworksIQ = artworksIQ.OrderBy(a => a.Title);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);

            ArtworkData = new ArtworkIndexData();
            ArtworkData.Artworks = await PaginatedList<Artwork>.CreateAsync(
                artworksIQ
                .AsNoTracking()
                .Include(i => i.Artist)
                .Include(i => i.Medium)
                .Include(i => i.Collection), pageIndex ?? 1, pageSize);
            
            if (id != null)
            {
                ArtworkID = id.Value;
                Artwork artwork = ArtworkData.Artworks
                    .Where(i => i.ArtworkID == id.Value).Single();
                ArtworkData.Artist = artwork.Artist;
                ArtworkData.Medium = artwork.Medium;
                ArtworkData.Collection = artwork.Collection;
            }
        }
    }
}
