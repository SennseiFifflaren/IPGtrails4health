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
    public class TiposAlojamentoController : Controller
    {
        private readonly TurismoDbContext _context;

        public TiposAlojamentoController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: TiposAlojamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAlojamentos.ToListAsync());
        }

        // GET: TiposAlojamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos
                .SingleOrDefaultAsync(m => m.TipoAlojamentoId == id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            return View(tipoAlojamento);
        }

        // GET: TiposAlojamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposAlojamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAlojamentoId,Nome")] TipoAlojamento tipoAlojamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAlojamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAlojamento);
        }

        // GET: TiposAlojamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos.SingleOrDefaultAsync(m => m.TipoAlojamentoId == id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }
            return View(tipoAlojamento);
        }

        // POST: TiposAlojamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoAlojamentoId,Nome")] TipoAlojamento tipoAlojamento)
        {
            if (id != tipoAlojamento.TipoAlojamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAlojamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAlojamentoExists(tipoAlojamento.TipoAlojamentoId))
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
            return View(tipoAlojamento);
        }

        // GET: TiposAlojamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlojamento = await _context.TipoAlojamentos
                .SingleOrDefaultAsync(m => m.TipoAlojamentoId == id);
            if (tipoAlojamento == null)
            {
                return NotFound();
            }

            return View(tipoAlojamento);
        }

        // POST: TiposAlojamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAlojamento = await _context.TipoAlojamentos.SingleOrDefaultAsync(m => m.TipoAlojamentoId == id);
            _context.TipoAlojamentos.Remove(tipoAlojamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAlojamentoExists(int id)
        {
            return _context.TipoAlojamentos.Any(e => e.TipoAlojamentoId == id);
        }
    }
}
