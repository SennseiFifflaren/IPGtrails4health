using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPGTrails4Health.Data;
using IPGTrails4Health.Models;

namespace IPGTrails4Health.Controllers
{
    public class AlojamentosTrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public AlojamentosTrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: AlojamentosTrilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.AlojamentosTrilhos.Include(a => a.Alojamento).Include(a => a.Trilho);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: AlojamentosTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamentoTrilho = await _context.AlojamentosTrilhos
                .Include(a => a.Alojamento)
                .Include(a => a.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (alojamentoTrilho == null)
            {
                return NotFound();
            }

            return View(alojamentoTrilho);
        }

        // GET: AlojamentosTrilhos/Create
        public IActionResult Create()
        {
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "AlojamentoId", "Contacto");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada");
            return View();
        }

        // POST: AlojamentosTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlojamentoTrilhoId,AlojamentoId,TrilhoId")] AlojamentoTrilho alojamentoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alojamentoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "AlojamentoId", "Contacto", alojamentoTrilho.AlojamentoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", alojamentoTrilho.TrilhoId);
            return View(alojamentoTrilho);
        }

        // GET: AlojamentosTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamentoTrilho = await _context.AlojamentosTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (alojamentoTrilho == null)
            {
                return NotFound();
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "AlojamentoId", "Contacto", alojamentoTrilho.AlojamentoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", alojamentoTrilho.TrilhoId);
            return View(alojamentoTrilho);
        }

        // POST: AlojamentosTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlojamentoTrilhoId,AlojamentoId,TrilhoId")] AlojamentoTrilho alojamentoTrilho)
        {
            if (id != alojamentoTrilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamentoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamentoTrilhoExists(alojamentoTrilho.TrilhoId))
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
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "AlojamentoId", "Contacto", alojamentoTrilho.AlojamentoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", alojamentoTrilho.TrilhoId);
            return View(alojamentoTrilho);
        }

        // GET: AlojamentosTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamentoTrilho = await _context.AlojamentosTrilhos
                .Include(a => a.Alojamento)
                .Include(a => a.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (alojamentoTrilho == null)
            {
                return NotFound();
            }

            return View(alojamentoTrilho);
        }

        // POST: AlojamentosTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamentoTrilho = await _context.AlojamentosTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.AlojamentosTrilhos.Remove(alojamentoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamentoTrilhoExists(int id)
        {
            return _context.AlojamentosTrilhos.Any(e => e.TrilhoId == id);
        }
    }
}
