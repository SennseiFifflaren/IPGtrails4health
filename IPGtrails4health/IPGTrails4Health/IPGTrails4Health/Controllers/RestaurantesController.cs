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
    public class RestaurantesController : Controller
    {
        private readonly TurismoDbContext _context;

        public RestaurantesController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.Restaurantes.Include(r => r.Localidade);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurantes
                .Include(r => r.Localidade)
                .SingleOrDefaultAsync(m => m.RestauranteId == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "Nome");
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestauranteId,Nome,Descricao,LocalidadeId,Contacto")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "Nome", restaurante.LocalidadeId);
            return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurantes.SingleOrDefaultAsync(m => m.RestauranteId == id);
            if (restaurante == null)
            {
                return NotFound();
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "Nome", restaurante.LocalidadeId);
            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestauranteId,Nome,Descricao,LocalidadeId,Contacto")] Restaurante restaurante)
        {
            if (id != restaurante.RestauranteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestauranteExists(restaurante.RestauranteId))
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
            ViewData["LocalidadeId"] = new SelectList(_context.Localidades, "LocalidadeId", "LocalidadeId", restaurante.LocalidadeId);
            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurante = await _context.Restaurantes
                .Include(r => r.Localidade)
                .SingleOrDefaultAsync(m => m.RestauranteId == id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurante = await _context.Restaurantes.SingleOrDefaultAsync(m => m.RestauranteId == id);
            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurantes.Any(e => e.RestauranteId == id);
        }
    }
}
