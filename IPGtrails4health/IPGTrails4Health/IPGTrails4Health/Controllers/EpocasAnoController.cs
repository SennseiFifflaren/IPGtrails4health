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
    public class EpocasAnoController : Controller
    {
        private readonly TurismoDbContext _context;

        public EpocasAnoController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: EpocasAno
        public async Task<IActionResult> Index()
        {
            return View(await _context.EpocasAno.ToListAsync());
        }

        // GET: EpocasAno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAno = await _context.EpocasAno
                .SingleOrDefaultAsync(m => m.EpocaAnoId == id);
            if (epocaAno == null)
            {
                return NotFound();
            }

            return View(epocaAno);
        }

        // GET: EpocasAno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EpocasAno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpocaAnoId,Nome")] EpocaAno epocaAno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epocaAno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epocaAno);
        }

        // GET: EpocasAno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAno = await _context.EpocasAno.SingleOrDefaultAsync(m => m.EpocaAnoId == id);
            if (epocaAno == null)
            {
                return NotFound();
            }
            return View(epocaAno);
        }

        // POST: EpocasAno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpocaAnoId,Nome")] EpocaAno epocaAno)
        {
            if (id != epocaAno.EpocaAnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epocaAno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpocaAnoExists(epocaAno.EpocaAnoId))
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
            return View(epocaAno);
        }

        // GET: EpocasAno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAno = await _context.EpocasAno
                .SingleOrDefaultAsync(m => m.EpocaAnoId == id);
            if (epocaAno == null)
            {
                return NotFound();
            }

            return View(epocaAno);
        }

        // POST: EpocasAno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epocaAno = await _context.EpocasAno.SingleOrDefaultAsync(m => m.EpocaAnoId == id);
            _context.EpocasAno.Remove(epocaAno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpocaAnoExists(int id)
        {
            return _context.EpocasAno.Any(e => e.EpocaAnoId == id);
        }
    }
}
