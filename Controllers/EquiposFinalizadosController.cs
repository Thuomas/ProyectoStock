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
    public class EquiposFinalizadosController : Controller
    {
        private readonly StockContext _context;

        public EquiposFinalizadosController(StockContext context)
        {
            _context = context;
        }

        // GET: EquiposFinalizados
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.EquiposFinalizados.Include(e => e.OrdenProduccion);
            return View(await stockContext.ToListAsync());
        }

        // GET: EquiposFinalizados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equiposFinalizados = await _context.EquiposFinalizados
                .Include(e => e.OrdenProduccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equiposFinalizados == null)
            {
                return NotFound();
            }

            return View(equiposFinalizados);
        }

        // GET: EquiposFinalizados/Create
        public IActionResult Create()
        {
            ViewData["OrdenProduccionId"] = new SelectList(_context.Produccion, "Id", "OrdenProduccion","Id");
            return View();
        }

        // POST: EquiposFinalizados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Desde,Hasta,Cantidad,Restante,OrdenProduccionId,OrdenProduccion")] EquiposFinalizados equiposFinalizados)
        {
            ModelState.Remove("OrdenProduccion");
            if (ModelState.IsValid)
            {
                _context.Add(equiposFinalizados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdenProduccionId"] = new SelectList(_context.Produccion, "Id","OrdenProduccion", "Id");
            return View(equiposFinalizados);
        }

        // GET: EquiposFinalizados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var equiposFinalizados = await _context.EquiposFinalizados.FindAsync(id);
            if (equiposFinalizados == null)
            {
                return NotFound();
            }
            ViewData["OrdenProduccionId"] = new SelectList(_context.Produccion, "Id","OrdenProduccion", "Id");
            return View(equiposFinalizados);
        }

        // POST: EquiposFinalizados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Desde,Hasta,Cantidad,Restante,OrdenProduccionId")] EquiposFinalizados equiposFinalizados)
        {
            if (id != equiposFinalizados.Id)
            {
                return NotFound();
            }
                ModelState.Remove("OrdenProduccionId");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equiposFinalizados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquiposFinalizadosExists(equiposFinalizados.Id))
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
            ViewData["OrdenProduccionId"] = new SelectList(_context.Produccion, "Id", "OrdenProduccion", "Id");
            return View(equiposFinalizados);
        }

        // GET: EquiposFinalizados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equiposFinalizados = await _context.EquiposFinalizados
                .Include(e => e.OrdenProduccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equiposFinalizados == null)
            {
                return NotFound();
            }

            return View(equiposFinalizados);
        }

        // POST: EquiposFinalizados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equiposFinalizados = await _context.EquiposFinalizados.FindAsync(id);
            if (equiposFinalizados != null)
            {
                _context.EquiposFinalizados.Remove(equiposFinalizados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquiposFinalizadosExists(int id)
        {
            return _context.EquiposFinalizados.Any(e => e.Id == id);
        }
    }
}
