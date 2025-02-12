using LernAndDelete.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LernAndDelete.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Area("User")]
        public async Task<IActionResult> Index()
        {
            var response = await _context.Books.ToListAsync();
            return View(response);
        }
    }
}
