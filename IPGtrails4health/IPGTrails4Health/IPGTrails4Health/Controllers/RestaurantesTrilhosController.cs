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
    public class RestaurantesTrilhosController : Controller
    {
        private readonly TurismoDbContext _context;

        public RestaurantesTrilhosController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: RestaurantesTrilhos
        public async Task<IActionResult> Index()
        {
            var turismoDbContext = _context.RestaurantesTrilhos.Include(r => r.Restaurante).Include(r => r.Trilho);
            return View(await turismoDbContext.ToListAsync());
        }

        // GET: RestaurantesTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restauranteTrilho = await _context.RestaurantesTrilhos
                .Include(r => r.Restaurante)
                .Include(r => r.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (restauranteTrilho == null)
            {
                return NotFound();
            }

            return View(restauranteTrilho);
        }

        // GET: RestaurantesTrilhos/Create
        public IActionResult Create()
        {
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Nome");
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome");
            return View();
        }

        // POST: RestaurantesTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestauranteTrilhoId,TrilhoId,RestauranteId")] RestauranteTrilho restauranteTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restauranteTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Descricao", restauranteTrilho.RestauranteId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Chegada", restauranteTrilho.TrilhoId);
            return View(restauranteTrilho);
        }

        // GET: RestaurantesTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restauranteTrilho = await _context.RestaurantesTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (restauranteTrilho == null)
            {
                return NotFound();
            }
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "Nome", restauranteTrilho.RestauranteId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "Nome", restauranteTrilho.TrilhoId);
            return View(restauranteTrilho);
        }

        // POST: RestaurantesTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestauranteTrilhoId,TrilhoId,RestauranteId")] RestauranteTrilho restauranteTrilho)
        {
            if (id != restauranteTrilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restauranteTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestauranteTrilhoExists(restauranteTrilho.TrilhoId))
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
            ViewData["RestauranteId"] = new SelectList(_context.Restaurantes, "RestauranteId", "RestauranteId", restauranteTrilho.RestauranteId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilhos, "TrilhoId", "RestauranteId", restauranteTrilho.TrilhoId);
            return View(restauranteTrilho);
        }

        // GET: RestaurantesTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restauranteTrilho = await _context.RestaurantesTrilhos
                .Include(r => r.Restaurante)
                .Include(r => r.Trilho)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (restauranteTrilho == null)
            {
                return NotFound();
            }

            return View(restauranteTrilho);
        }

        // POST: RestaurantesTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restauranteTrilho = await _context.RestaurantesTrilhos.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.RestaurantesTrilhos.Remove(restauranteTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestauranteTrilhoExists(int id)
        {
            return _context.RestaurantesTrilhos.Any(e => e.TrilhoId == id);
        }
    }
}
