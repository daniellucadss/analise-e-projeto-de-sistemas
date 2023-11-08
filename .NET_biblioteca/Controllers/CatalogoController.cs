#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace NET_biblioteca.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly MyDbContext _context;

        public CatalogoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Catalogo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catalogo.ToListAsync());
        }

        // GET: Catalogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // GET: Catalogo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAutor,NumeroCopias")] Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogo);
        }

        // GET: Catalogo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return NotFound();
            }
            return View(catalogo);
        }

        // POST: Catalogo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAutor,NumeroCopias")] Catalogo catalogo)
        {
            if (id != catalogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoExists(catalogo.Id))
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
            return View(catalogo);
        }

        // GET: Catalogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // POST: Catalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogo = await _context.Catalogo.FindAsync(id);
            _context.Catalogo.Remove(catalogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoExists(int id)
        {
            return _context.Catalogo.Any(e => e.Id == id);
        }
    }
}
