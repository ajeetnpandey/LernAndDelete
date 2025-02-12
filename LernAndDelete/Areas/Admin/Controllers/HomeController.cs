using LernAndDelete.Areas.Admin.Models;
using LernAndDelete.Data;
using LernAndDelete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LernAndDelete.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _context.Books.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Book Added Successfully";
                return RedirectToAction("Index", "Home", new { area = "Admin" });  // Redirect to Index after successful creation
            }
            return View(book);  // Return the same view with validation messages if invalid
        }

        public IActionResult Electranics()
        {
            return View();
        }

    }
}
