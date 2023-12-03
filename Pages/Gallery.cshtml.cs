using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using FaulknerCountyMuseumGallery.Models.GalleryViewModels;  // Add VM

namespace FaulknerCountyMuseumGallery.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly FaulknerCountyMuseumGallery.Data.GalleryContext _context;
        private readonly IConfiguration Configuration;

        public GalleryModel(FaulknerCountyMuseumGallery.Data.GalleryContext context,
                            IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string CurrentFilter { get; set; }
        public ArtworkIndexData ArtworkData { get; set; }
        public List<Collection> collectionList {get; set; }
        public int ArtworkID { get; set; }


        public async Task OnGetAsync(int? id,
            string currentFilter, string searchString, int collectionID, int? pageIndex)
        {
            collectionList = (from a in _context.Collections select a).ToList();
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
                artworksIQ = artworksIQ.Where(a => a.Title.ToUpper().Contains(searchString.ToUpper())
                                        || a.Artist.Name.ToUpper().Contains(searchString.ToUpper())
                                        || a.Medium.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (collectionID != 0)
            {
                artworksIQ = artworksIQ.Where(a => a.Collection.ID.Equals(collectionID));
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
