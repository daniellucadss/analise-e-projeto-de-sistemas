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
    public class LivrosController : Controller
    {
        private readonly MyDbContext _context;

        public LivrosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAutor,NomeLivro,QuantidadeLivro")] Livros livros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livros);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros.FindAsync(id);
            if (livros == null)
            {
                return NotFound();
            }
            return View(livros);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAutor,NomeLivro,QuantidadeLivro")] Livros livros)
        {
            if (id != livros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivrosExists(livros.Id))
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
            return View(livros);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livros = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
