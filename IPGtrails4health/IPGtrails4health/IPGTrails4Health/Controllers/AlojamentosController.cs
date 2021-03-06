﻿using System;
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
    public class AlojamentosController : Controller
    {
        private readonly TurismoContext _context;

        public AlojamentosController(TurismoContext context)
        {
            _context = context;
        }

        // GET: Alojamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alojamento.ToListAsync());
        }

        // GET: Alojamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamento
                .SingleOrDefaultAsync(m => m.ID == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // GET: Alojamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alojamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tipo,Nome,Descricao,Local,PrecoMin,PrecoMax")] Alojamento alojamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alojamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alojamento);
        }

        // GET: Alojamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamento.SingleOrDefaultAsync(m => m.ID == id);
            if (alojamento == null)
            {
                return NotFound();
            }
            return View(alojamento);
        }

        // POST: Alojamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tipo,Nome,Descricao,Local,PrecoMin,PrecoMax")] Alojamento alojamento)
        {
            if (id != alojamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlojamentoExists(alojamento.ID))
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
            return View(alojamento);
        }

        // GET: Alojamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamento
                .SingleOrDefaultAsync(m => m.ID == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // POST: Alojamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamento = await _context.Alojamento.SingleOrDefaultAsync(m => m.ID == id);
            _context.Alojamento.Remove(alojamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlojamentoExists(int id)
        {
            return _context.Alojamento.Any(e => e.ID == id);
        }
    }
}
