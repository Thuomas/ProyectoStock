using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Models;

namespace Stock.Controllers
{
    public class ProduccionController : Controller
    {
        private readonly StockContext _context;

        public ProduccionController(StockContext context)
        {
            _context = context;
        }

        // GET: Produccion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produccion.ToListAsync());
        }

        // GET: Produccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .Include(m=>m.EquiposFinalizados)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // GET: Produccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,OrdenProduccion,Equipo,Cantidad")] Produccion produccion)
        {
            ModelState.Remove("EquiposFinalizados");
            if (ModelState.IsValid)
            {
                _context.Add(produccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produccion);
        }

        // GET: Produccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion.FindAsync(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }

        // POST: Produccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,OrdenProduccion,Equipo,Cantidad")] Produccion produccion)
        {
            if (id != produccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduccionExists(produccion.Id))
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
            return View(produccion);
        }

        // GET: Produccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // POST: Produccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produccion = await _context.Produccion.FindAsync(id);
            if (produccion != null)
            {
                _context.Produccion.Remove(produccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduccionExists(int id)
        {
            return _context.Produccion.Any(e => e.Id == id);
        }
    }
}
