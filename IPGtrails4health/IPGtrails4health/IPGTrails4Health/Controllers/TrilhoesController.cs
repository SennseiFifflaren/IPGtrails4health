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
    public class TrilhoesController : Controller
    {
        private readonly TurismoContext _context;

        public TrilhoesController(TurismoContext context)
        {
            _context = context;
        }

        // GET: Trilhoes
        public async Task<IActionResult> Index()
        {
            var turismoContext = _context.Trilhos.Include(t => t.Restaurante);
            return View(await turismoContext.ToListAsync());
        }

        // GET: Trilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Restaurante)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhoes/Create
        public IActionResult Create()
        {
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Descricao");
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoId,Nome,Partida,Chegada,Distancia,Duracao,Dificuldade,Percurso,Sazonalidade,RestauranteId,EstadoTrilho")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Descricao", trilho.RestauranteId);
            return View(trilho);
        }

        // GET: Trilhoes/Edit/5
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
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Descricao", trilho.RestauranteId);
            return View(trilho);
        }

        // POST: Trilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoId,Nome,Partida,Chegada,Distancia,Duracao,Dificuldade,Percurso,Sazonalidade,RestauranteId,EstadoTrilho")] Trilho trilho)
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
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Descricao", trilho.RestauranteId);
            return View(trilho);
        }

        // GET: Trilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Restaurante)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhoes/Delete/5
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
