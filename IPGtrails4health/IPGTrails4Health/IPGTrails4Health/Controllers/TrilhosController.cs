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
    public class TrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public TrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: Trilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.Trilhos.Include(t => t.Dificuldade).Include(t => t.EpocaAno);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: Trilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Dificuldade)
                .Include(t => t.EpocaAno)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhos/Create
        public IActionResult Create()
        {
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "Nome");
            ViewData["EpocaAnoId"] = new SelectList(_context.EpocasAno, "EpocaAnoId", "Nome");
            return View();
        }

        // POST: Trilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoId,Nome,Partida,Chegada,Distancia,Duracao,DificuldadeId,EpocaAnoId")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId", trilho.DificuldadeId);
            ViewData["EpocaAnoId"] = new SelectList(_context.EpocasAno, "EpocaAnoId", "EpocaAnoId", trilho.EpocaAnoId);
            return View(trilho);
        }

        // GET: Trilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "Nome", trilho.DificuldadeId);
            ViewData["EpocaAnoId"] = new SelectList(_context.EpocasAno, "EpocaAnoId", "Nome", trilho.EpocaAnoId);
            return View(trilho);
        }

        // POST: Trilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoId,Nome,Partida,Chegada,Distancia,Duracao,DificuldadeId,EpocaAnoId")] Trilho trilho)
        {
            if (id != trilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhoExists(trilho.TrilhoId))
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
            ViewData["DificuldadeId"] = new SelectList(_context.Dificuldades, "DificuldadeId", "DificuldadeId", trilho.DificuldadeId);
            ViewData["EpocaAnoId"] = new SelectList(_context.EpocasAno, "EpocaAnoId", "EpocaAnoId", trilho.EpocaAnoId);
            return View(trilho);
        }

        // GET: Trilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Dificuldade)
                .Include(t => t.EpocaAno)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.Trilhos.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrilhoId == id);
        }
    }
}
