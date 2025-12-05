using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCvSite.Data;
using System.Linq;

namespace MyCvSite.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var photos = _context.Photos
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(photos);
        }
    }
}
