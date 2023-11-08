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
    public class BibliotecariosController : Controller
    {
        private readonly MyDbContext _context;

        public BibliotecariosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Bibliotecarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bibliotecario.ToListAsync());
        }

        // GET: Bibliotecarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bibliotecario == null)
            {
                return NotFound();
            }

            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bibliotecarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Contato")] Bibliotecario bibliotecario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bibliotecario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecario.FindAsync(id);
            if (bibliotecario == null)
            {
                return NotFound();
            }
            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Contato")] Bibliotecario bibliotecario)
        {
            if (id != bibliotecario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bibliotecario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecarioExists(bibliotecario.Id))
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
            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bibliotecario == null)
            {
                return NotFound();
            }

            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bibliotecario = await _context.Bibliotecario.FindAsync(id);
            _context.Bibliotecario.Remove(bibliotecario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecarioExists(int id)
        {
            return _context.Bibliotecario.Any(e => e.Id == id);
        }
    }
}
