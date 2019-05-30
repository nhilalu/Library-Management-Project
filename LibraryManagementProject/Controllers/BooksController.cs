using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementProject.Data;
using LibraryManagementProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementProject.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<LibraryUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<LibraryUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Books
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Books
                .Include("Author")
                .ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        private LibraryUser GetCurrentUser()
        {
            return _userManager.FindByNameAsync(User.Identity.Name).Result;
        }

        public async Task<IActionResult> Borrow(int id)
        {
            var book = _context
                .Books
                .Where(b => b.BookId == id)
                .FirstOrDefault();

            var currentUser = GetCurrentUser();

            Lend lend = new Lend()
            {
                User = currentUser,
                Book = book,
                LendDate = DateTime.Now
            };

            book.Lend = lend;
            currentUser.Lends.Add(lend);

            _context.Lends.Add(lend);
            _context.Books.Update(book);
            _context.Users.Update(currentUser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", -1);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName", -1);

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, string AuthorName, string CategoryName)
        {
            if (book.AuthorId == 0)
            {
                Author author = new Author()
                {
                    AuthorName = AuthorName,
                    Publisher = book.Publisher
                };

                _context.Add(author);
                _context.SaveChanges();

                book.AuthorId = author.AuthorId;
                book.AuthorName = AuthorName;
            }

            if (book.CategoryId == 0)
            {
                Category category = new Category()
                {
                    CategoryName = CategoryName
                };

                _context.Add(category);
                _context.SaveChanges();

                book.CategoryId = category.CategoryId;
                book.CategoryName = CategoryName;
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,SerialNumber,Author,Publisher")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
