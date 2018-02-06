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
    public class PontosInteresseTrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public PontosInteresseTrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: PontosInteresseTrilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.PontosInteresseTrilho.Include(p => p.PontoInteresse).Include(p => p.Trilho);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: PontosInteresseTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresseTrilho = await _context.PontosInteresseTrilho
                .Include(p => p.PontoInteresse)
                .Include(p => p.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (pontoInteresseTrilho == null)
            {
                return NotFound();
            }

            return View(pontoInteresseTrilho);
        }

        // GET: PontosInteresseTrilhos/Create
        public IActionResult Create()
        {
            ViewData["PontoInteresseId"] = new SelectList(_context.PontosInteresse, "PontoInteresseId", "Nome");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View();
        }

        // POST: PontosInteresseTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontoInteresseTrilhoId,TrilhoId,PontoInteresseId")] PontoInteresseTrilho pontoInteresseTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoInteresseTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PontoInteresseId"] = new SelectList(_context.PontosInteresse, "PontoInteresseId", "PontoInteresseId", pontoInteresseTrilho.PontoInteresseId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", pontoInteresseTrilho.TrilhoId);
            return View(pontoInteresseTrilho);
        }

        // GET: PontosInteresseTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresseTrilho = await _context.PontosInteresseTrilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (pontoInteresseTrilho == null)
            {
                return NotFound();
            }
            ViewData["PontoInteresseId"] = new SelectList(_context.PontosInteresse, "PontoInteresseId", "PontoInteresseId", pontoInteresseTrilho.PontoInteresseId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", pontoInteresseTrilho.TrilhoId);
            return View(pontoInteresseTrilho);
        }

        // POST: PontosInteresseTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontoInteresseTrilhoId,TrilhoId,PontoInteresseId")] PontoInteresseTrilho pontoInteresseTrilho)
        {
            if (id != pontoInteresseTrilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoInteresseTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoInteresseTrilhoExists(pontoInteresseTrilho.TrilhoId))
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
            ViewData["PontoInteresseId"] = new SelectList(_context.PontosInteresse, "PontoInteresseId", "PontoInteresseId", pontoInteresseTrilho.PontoInteresseId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", pontoInteresseTrilho.TrilhoId);
            return View(pontoInteresseTrilho);
        }

        // GET: PontosInteresseTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresseTrilho = await _context.PontosInteresseTrilho
                .Include(p => p.PontoInteresse)
                .Include(p => p.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (pontoInteresseTrilho == null)
            {
                return NotFound();
            }

            return View(pontoInteresseTrilho);
        }

        // POST: PontosInteresseTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoInteresseTrilho = await _context.PontosInteresseTrilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.PontosInteresseTrilho.Remove(pontoInteresseTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoInteresseTrilhoExists(int id)
        {
            return _context.PontosInteresseTrilho.Any(e => e.TrilhoId == id);
        }
    }
}
