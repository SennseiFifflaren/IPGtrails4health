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
    public class TiposPontoInteresseController : Controller
    {
        private readonly TurismoDbContext _context;

        public TiposPontoInteresseController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: TiposPontoInteresse
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPontosInteresse.ToListAsync());
        }

        // GET: TiposPontoInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoInteresse = await _context.TipoPontosInteresse
                .SingleOrDefaultAsync(m => m.TipoPontoInteresseId == id);
            if (tipoPontoInteresse == null)
            {
                return NotFound();
            }

            return View(tipoPontoInteresse);
        }

        // GET: TiposPontoInteresse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposPontoInteresse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPontoInteresseId,Nome")] TipoPontoInteresse tipoPontoInteresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPontoInteresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPontoInteresse);
        }

        // GET: TiposPontoInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoInteresse = await _context.TipoPontosInteresse.SingleOrDefaultAsync(m => m.TipoPontoInteresseId == id);
            if (tipoPontoInteresse == null)
            {
                return NotFound();
            }
            return View(tipoPontoInteresse);
        }

        // POST: TiposPontoInteresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPontoInteresseId,Nome")] TipoPontoInteresse tipoPontoInteresse)
        {
            if (id != tipoPontoInteresse.TipoPontoInteresseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPontoInteresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPontoInteresseExists(tipoPontoInteresse.TipoPontoInteresseId))
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
            return View(tipoPontoInteresse);
        }

        // GET: TiposPontoInteresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPontoInteresse = await _context.TipoPontosInteresse
                .SingleOrDefaultAsync(m => m.TipoPontoInteresseId == id);
            if (tipoPontoInteresse == null)
            {
                return NotFound();
            }

            return View(tipoPontoInteresse);
        }

        // POST: TiposPontoInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPontoInteresse = await _context.TipoPontosInteresse.SingleOrDefaultAsync(m => m.TipoPontoInteresseId == id);
            _context.TipoPontosInteresse.Remove(tipoPontoInteresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPontoInteresseExists(int id)
        {
            return _context.TipoPontosInteresse.Any(e => e.TipoPontoInteresseId == id);
        }
    }
}
