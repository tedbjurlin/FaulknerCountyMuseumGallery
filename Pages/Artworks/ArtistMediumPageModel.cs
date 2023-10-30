using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FaulknerCountyMuseumGallery.Pages.Courses
{
    public class ArtistMediumPageModel : PageModel
    {
        public SelectList ArtistNameSL { get; set; }
        public SelectList MediumNameSL { get; set; }

        public void PopulateArtistsDropDownList(GalleryContext _context,
            object selectedArtist = null)
        {
            var artistsQuery = from a in _context.Artists
                                   orderby a.Name // Sort by name.
                                   select a;

            ArtistNameSL = new SelectList(artistsQuery.AsNoTracking(),
                nameof(Artist.ID),
                nameof(Artist.Name),
                selectedArtist);
        }

        public void PopulateMediumsDropDownList(GalleryContext _context,
            object selectedMedium = null)
        {
            var mediumsQuery = from m in _context.Mediums
                                   orderby m.Description // Sort by name.
                                   select m;

            MediumNameSL = new SelectList(mediumsQuery.AsNoTracking(),
                nameof(Medium.ID),
                nameof(Medium.Description),
                selectedMedium);
        }
    }
}