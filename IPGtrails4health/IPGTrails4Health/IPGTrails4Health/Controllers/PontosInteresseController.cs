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
    public class PontosInteresseController : Controller
    {
        private readonly TurismoDbContext _context;

        public PontosInteresseController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: PontosInteresse
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.PontosInteresse.Include(p => p.Localidade).Include(p => p.Tipo);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: PontosInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontosInteresse
                .Include(p => p.Localidade)
                .Include(p => p.Tipo)
                .SingleOrDefaultAsync(m => m.PontoInteresseId == id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Create
        public IActionResult Create()
        {
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "Nome");
            ViewData["TipoPontoInteresseId"] = new SelectList(_context.TipoPontosInteresse, "TipoPontoInteresseId", "Nome");
            return View();
        }

        // POST: PontosInteresse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontoInteresseId,Nome,Observacoes,Local,LocalidadeId,TipoPontoInteresseId")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoInteresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "LocalidadeId", pontoInteresse.LocalidadeId);
            ViewData["TipoPontoInteresseId"] = new SelectList(_context.TipoPontosInteresse, "TipoPontoInteresseId", "TipoPontoInteresseId", pontoInteresse.TipoPontoInteresseId);
            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontosInteresse.SingleOrDefaultAsync(m => m.PontoInteresseId == id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "Nome", pontoInteresse.LocalidadeId);
            ViewData["TipoPontoInteresseId"] = new SelectList(_context.TipoPontosInteresse, "TipoPontoInteresseId", "Nome", pontoInteresse.TipoPontoInteresseId);
            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontoInteresseId,Nome,Observacoes,Local,LocalidadeId,TipoPontoInteresseId")] PontoInteresse pontoInteresse)
        {
            if (id != pontoInteresse.PontoInteresseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoInteresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoInteresseExists(pontoInteresse.PontoInteresseId))
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
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "LocalidadeId", pontoInteresse.LocalidadeId);
            ViewData["TipoPontoInteresseId"] = new SelectList(_context.TipoPontosInteresse, "TipoPontoInteresseId", "TipoPontoInteresseId", pontoInteresse.TipoPontoInteresseId);
            return View(pontoInteresse);
        }

        // GET: PontosInteresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontosInteresse
                .Include(p => p.Localidade)
                .Include(p => p.Tipo)
                .SingleOrDefaultAsync(m => m.PontoInteresseId == id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // POST: PontosInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoInteresse = await _context.PontosInteresse.SingleOrDefaultAsync(m => m.PontoInteresseId == id);
            _context.PontosInteresse.Remove(pontoInteresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoInteresseExists(int id)
        {
            return _context.PontosInteresse.Any(e => e.PontoInteresseId == id);
        }
    }
}
