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
    public class AreasDescansoController : Controller
    {
        private readonly TurismoContext _context;

        public AreasDescansoController(TurismoContext context)
        {
            _context = context;
        }

        // GET: AreasDescanso
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreasDescanso.ToListAsync());
        }

        // GET: AreasDescanso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescanso = await _context.AreasDescanso
                .SingleOrDefaultAsync(m => m.AreaDescansoId == id);
            if (areaDescanso == null)
            {
                return NotFound();
            }

            return View(areaDescanso);
        }

        // GET: AreasDescanso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreasDescanso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaDescansoId,Tipo,Nome,Descricao,Local")] AreaDescanso areaDescanso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaDescanso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaDescanso);
        }

        // GET: AreasDescanso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescanso = await _context.AreasDescanso.SingleOrDefaultAsync(m => m.AreaDescansoId == id);
            if (areaDescanso == null)
            {
                return NotFound();
            }
            return View(areaDescanso);
        }

        // POST: AreasDescanso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaDescansoId,Tipo,Nome,Descricao,Local")] AreaDescanso areaDescanso)
        {
            if (id != areaDescanso.AreaDescansoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaDescanso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaDescansoExists(areaDescanso.AreaDescansoId))
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
            return View(areaDescanso);
        }

        // GET: AreasDescanso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaDescanso = await _context.AreasDescanso
                .SingleOrDefaultAsync(m => m.AreaDescansoId == id);
            if (areaDescanso == null)
            {
                return NotFound();
            }

            return View(areaDescanso);
        }

        // POST: AreasDescanso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaDescanso = await _context.AreasDescanso.SingleOrDefaultAsync(m => m.AreaDescansoId == id);
            _context.AreasDescanso.Remove(areaDescanso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaDescansoExists(int id)
        {
            return _context.AreasDescanso.Any(e => e.AreaDescansoId == id);
        }
    }
}
