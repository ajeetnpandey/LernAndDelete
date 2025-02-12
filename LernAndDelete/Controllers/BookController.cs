using LernAndDelete.Models;
using LernAndDelete.SpecificationPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LernAndDelete.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IActionResult> Index(string author)
        //{
        //    var spec = new BooksByAuthorSpecification(author);
        //    var books = await _unitOfWork.Books.FindAsync(spec);

        //    return View(books);
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var spec = new BooksByAuthorSpecification();
        //    var books = await _unitOfWork.Books.GetAllAsync();

        //    return View(books);
        //}


        [HttpGet]
        public async Task<IActionResult> Index(string authorSearch)
        {
            // Store the search term in ViewData so that it's retained after the form is submitted
            ViewData["AuthorSearch"] = authorSearch;

            // If no search term, return all books
            if (string.IsNullOrEmpty(authorSearch))
            {
                var spec = new BooksByAuthorSpecification(authorSearch);
                var books = await _unitOfWork.Books.FindAsync(spec);
                return View(books);
            }

            // Filter books by author if a search term is provided
            var filteredBooks = await _context.Books
                .Where(b => b.Author.Contains(authorSearch))
                .ToListAsync();

            return View(filteredBooks);
        }

        // Create book action
        [HttpGet]
        public async Task<IActionResult> Deatils(string  author)
        {
            var spec = new BooksByAuthorSpecification(author);
            var books = await _unitOfWork.Books.FindAsync(spec);
            return View(books);
        }

        // Create book action
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // Create book action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Books.AddAsync(book);
                await _unitOfWork.CompleteAsync();
                TempData["SuccessMessage"] = "Book added successfully!";
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }

}
