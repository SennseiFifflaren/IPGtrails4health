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
    public class AreasDescansoTrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public AreasDescansoTrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: AreasDescansoTrilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.AreasDescansoTrilhos.Include(a => a.AreaDescanso).Include(a => a.Trilho);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: AreasDescansoTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescansoTrilho = await _context.AreasDescansoTrilhos
                .Include(a => a.AreaDescanso)
                .Include(a => a.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (areaDescansoTrilho == null)
            {
                return NotFound();
            }

            return View(areaDescansoTrilho);
        }

        // GET: AreasDescansoTrilhos/Create
        public IActionResult Create()
        {
            ViewData["AreaDescansoId"] = new SelectList(_context.AreasDescanso, "AreaDescansoId", "Nome");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View();
        }

        // POST: AreasDescansoTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaDescansoTrilhoId,TrilhoId,AreaDescansoId")] AreaDescansoTrilho areaDescansoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaDescansoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaDescansoId"] = new SelectList(_context.AreasDescanso, "AreaDescansoId", "Descricao", areaDescansoTrilho.AreaDescansoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", areaDescansoTrilho.TrilhoId);
            return View(areaDescansoTrilho);
        }

        // GET: AreasDescansoTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescansoTrilho = await _context.AreasDescansoTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (areaDescansoTrilho == null)
            {
                return NotFound();
            }
            ViewData["AreaDescansoId"] = new SelectList(_context.AreasDescanso, "AreaDescansoId", "Descricao", areaDescansoTrilho.AreaDescansoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", areaDescansoTrilho.TrilhoId);
            return View(areaDescansoTrilho);
        }

        // POST: AreasDescansoTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaDescansoTrilhoId,TrilhoId,AreaDescansoId")] AreaDescansoTrilho areaDescansoTrilho)
        {
            if (id != areaDescansoTrilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaDescansoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaDescansoTrilhoExists(areaDescansoTrilho.TrilhoId))
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
            ViewData["AreaDescansoId"] = new SelectList(_context.AreasDescanso, "AreaDescansoId", "Descricao", areaDescansoTrilho.AreaDescansoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", areaDescansoTrilho.TrilhoId);
            return View(areaDescansoTrilho);
        }

        // GET: AreasDescansoTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescansoTrilho = await _context.AreasDescansoTrilhos
                .Include(a => a.AreaDescanso)
                .Include(a => a.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (areaDescansoTrilho == null)
            {
                return NotFound();
            }

            return View(areaDescansoTrilho);
        }

        // POST: AreasDescansoTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaDescansoTrilho = await _context.AreasDescansoTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.AreasDescansoTrilhos.Remove(areaDescansoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaDescansoTrilhoExists(int id)
        {
            return _context.AreasDescansoTrilhos.Any(e => e.TrilhoId == id);
        }
    }
}
