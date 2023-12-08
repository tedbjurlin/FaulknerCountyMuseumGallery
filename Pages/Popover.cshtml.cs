using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FaulknerCountyMuseumGallery.Data;
using FaulknerCountyMuseumGallery.Models;
using FaulknerCountyMuseumGallery.Models.GalleryViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FaulknerCountyMuseumGallery {
    public class PopoverModel : PageModel {
        public void OnGet()
        {
        }
    }
}