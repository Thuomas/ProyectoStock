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
    public class ObservacionController : Controller
    {
        private readonly StockContext _context;

        public ObservacionController(StockContext context)
        {
            _context = context;
        }

        // GET: Observacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Observacion.ToListAsync());
        }

        // GET: Observacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observacion = await _context.Observacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (observacion == null)
            {
                return NotFound();
            }

            return View(observacion);
        }

        // GET: Observacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Observacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firmwareVersion,grabador,numSerieGrabador,amp,bpm,Simulador,NumSerieSimulador,SoftAnalisis,Cantidad")] Observacion observacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(observacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(observacion);
        }

        // GET: Observacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observacion = await _context.Observacion.FindAsync(id);
            if (observacion == null)
            {
                return NotFound();
            }
            return View(observacion);
        }

        // POST: Observacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firmwareVersion,grabador,numSerieGrabador,amp,bpm,Simulador,NumSerieSimulador,SoftAnalisis,Cantidad")] Observacion observacion)
        {
            if (id != observacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(observacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObservacionExists(observacion.Id))
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
            return View(observacion);
        }

        // GET: Observacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observacion = await _context.Observacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (observacion == null)
            {
                return NotFound();
            }

            return View(observacion);
        }

        // POST: Observacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var observacion = await _context.Observacion.FindAsync(id);
            if (observacion != null)
            {
                _context.Observacion.Remove(observacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObservacionExists(int id)
        {
            return _context.Observacion.Any(e => e.Id == id);
        }
    }
}
