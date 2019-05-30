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

namespace LibraryManagementProject.Controllers
{
    [Authorize]

    public class LendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lends
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Lends
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToListAsync());
        }

        // GET: Lends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends
                .FirstOrDefaultAsync(m => m.LendId == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // GET: Lends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LendId")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lend);
        }

        // GET: Lends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends.FindAsync(id);
            if (lend == null)
            {
                return NotFound();
            }
            return View(lend);
        }

        // POST: Lends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LendId")] Lend lend)
        {
            if (id != lend.LendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendExists(lend.LendId))
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
            return View(lend);
        }

        // GET: Lends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lend = await _context.Lends
                .FirstOrDefaultAsync(m => m.LendId == id);
            if (lend == null)
            {
                return NotFound();
            }

            return View(lend);
        }

        // POST: Lends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lend = await _context.Lends.FindAsync(id);
            _context.Lends.Remove(lend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendExists(int id)
        {
            return _context.Lends.Any(e => e.LendId == id);
        }
    }
}
