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
    public class EstadosTrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public EstadosTrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: EstadosTrilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.EstadosTrilho.Include(e => e.Estado).Include(e => e.Trilho);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: EstadosTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilho
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }

        // GET: EstadosTrilhos/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View();
        }

        // POST: EstadosTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoTrilhoId,EstadoId,TrilhoId,DataInicio,DataFim,Causa")] EstadoTrilho estadoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "EstadoId", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }

        // GET: EstadosTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "EstadoId", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }

        // POST: EstadosTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoTrilhoId,EstadoId,TrilhoId,DataInicio,DataFim,Causa")] EstadoTrilho estadoTrilho)
        {
            if (id != estadoTrilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTrilhoExists(estadoTrilho.TrilhoId))
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
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "EstadoId", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }

        // GET: EstadosTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadosTrilho
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }

        // POST: EstadosTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTrilho = await _context.EstadosTrilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.EstadosTrilho.Remove(estadoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTrilhoExists(int id)
        {
            return _context.EstadosTrilho.Any(e => e.TrilhoId == id);
        }
    }
}
