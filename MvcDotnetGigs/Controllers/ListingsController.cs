using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MvcDotnetGigs.Data.Services;
using MvcDotnetGigs.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MvcDotnetGigs.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingsService _listingsService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ListingsController(IListingsService listingsService, IWebHostEnvironment webHostEnvironment)
        {
            _listingsService = listingsService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingVM listing)
        {
            if (listing.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string fileName = listing.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    listing.Image.CopyTo(fileStream);
                }

                var listObj = new Listing
                {
                    Company = listing.Company,
                    Title = listing.Title,
                    Location = listing.Location,
                    Email = listing.Email,
                    Website = listing.Website,
                    Tags = listing.Tags,
                    Description = listing.Description,
                    IdentityUserId = listing.IdentityUserId,
                    ImagePath = fileName,
                };
                await _listingsService.Add(listObj);
                return RedirectToAction("Index");
            }
            return View(listing);
        }
    }
}
