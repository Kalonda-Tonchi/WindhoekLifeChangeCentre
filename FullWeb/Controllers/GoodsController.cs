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
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Goods.Include(g => g.GoodsByCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .Include(g => g.GoodsByCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            ViewData["GoodsByCategoryId"] = new SelectList(_context.Set<GoodsByCategory>(), "Id", "CategoryName");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GoodsByCategoryId,ProductName,AmountOfGoodsDonating")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoodsByCategoryId"] = new SelectList(_context.Set<GoodsByCategory>(), "Id", "CategoryName", goods.GoodsByCategoryId);
            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }
            ViewData["GoodsByCategoryId"] = new SelectList(_context.Set<GoodsByCategory>(), "Id", "CategoryName", goods.GoodsByCategoryId);
            return View(goods);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GoodsByCategoryId,ProductName,AmountOfGoodsDonating")] Goods goods)
        {
            if (id != goods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsExists(goods.Id))
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
            ViewData["GoodsByCategoryId"] = new SelectList(_context.Set<GoodsByCategory>(), "Id", "CategoryName", goods.GoodsByCategoryId);
            return View(goods);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .Include(g => g.GoodsByCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsExists(int id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
