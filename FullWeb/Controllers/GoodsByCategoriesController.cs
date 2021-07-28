using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullWeb.Data;
using FullWeb.Models;


namespace FullWeb.Controllers
{
    public class GoodsByCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsByCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsByCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodsByCategory.ToListAsync());
        }

        // GET: GoodsByCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsByCategory = await _context.GoodsByCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsByCategory == null)
            {
                return NotFound();
            }

            return View(goodsByCategory);
        }

        // GET: GoodsByCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsByCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] GoodsByCategory goodsByCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsByCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsByCategory);
        }

        // GET: GoodsByCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsByCategory = await _context.GoodsByCategory.FindAsync(id);
            if (goodsByCategory == null)
            {
                return NotFound();
            }
            return View(goodsByCategory);
        }

        // POST: GoodsByCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] GoodsByCategory goodsByCategory)
        {
            if (id != goodsByCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsByCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsByCategoryExists(goodsByCategory.Id))
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
            return View(goodsByCategory);
        }

        // GET: GoodsByCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsByCategory = await _context.GoodsByCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsByCategory == null)
            {
                return NotFound();
            }

            return View(goodsByCategory);
        }

        // POST: GoodsByCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsByCategory = await _context.GoodsByCategory.FindAsync(id);
            _context.GoodsByCategory.Remove(goodsByCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsByCategoryExists(int id)
        {
            return _context.GoodsByCategory.Any(e => e.Id == id);
        }
    }
}
