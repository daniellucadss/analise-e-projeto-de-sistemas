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
    public class AlertasController : Controller
    {
        private readonly MyDbContext _context;

        public AlertasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Alertas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alertas.ToListAsync());
        }

        // GET: Alertas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertas == null)
            {
                return NotFound();
            }

            return View(alertas);
        }

        // GET: Alertas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alertas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEmissao,NomeLivro,DataRetorno,Multa")] Alertas alertas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alertas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alertas);
        }

        // GET: Alertas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas.FindAsync(id);
            if (alertas == null)
            {
                return NotFound();
            }
            return View(alertas);
        }

        // POST: Alertas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEmissao,NomeLivro,DataRetorno,Multa")] Alertas alertas)
        {
            if (id != alertas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertasExists(alertas.Id))
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
            return View(alertas);
        }

        // GET: Alertas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertas == null)
            {
                return NotFound();
            }

            return View(alertas);
        }

        // POST: Alertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alertas = await _context.Alertas.FindAsync(id);
            _context.Alertas.Remove(alertas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertasExists(int id)
        {
            return _context.Alertas.Any(e => e.Id == id);
        }
    }
}
