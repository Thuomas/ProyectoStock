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
    public class EntregasSmtController : Controller
    {
        private readonly StockContext _context;

        public EntregasSmtController(StockContext context)
        {
            _context = context;
        }

        // GET: EntregasSmt
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.EntregasSmt.Include(e => e.OrdenTrabajo);
            return View(await stockContext.ToListAsync());
        }

        // GET: EntregasSmt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregasSmt = await _context.EntregasSmt
                .Include(e => e.OrdenTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregasSmt == null)
            {
                return NotFound();
            }

            return View(entregasSmt);
        }

        // GET: EntregasSmt/Create
        public IActionResult Create()
        {
            ViewData["OrdenTrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo", "Id");
            return View();
        }

        // POST: EntregasSmt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Remito,OrdenTrabajoId,Cantidad,CantidadRestante")] EntregasSmt entregasSmt)
        {
            ModelState.Remove("OrdenTrabajo");
            if (ModelState.IsValid)
            {
                _context.Add(entregasSmt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdenTrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajoId", "Id");
            return View(entregasSmt);
        }

        // GET: EntregasSmt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregasSmt = await _context.EntregasSmt.FindAsync(id);
            if (entregasSmt == null)
            {
                return NotFound();
            }
            ViewData["OrdenTrabajoId"] = new SelectList(_context.Trabajo, "Id", "OrdenTrabajo", "Id");
            return View(entregasSmt);
        }

        // POST: EntregasSmt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Remito,OrdenTrabajoId,Cantidad,CantidadRestante")] EntregasSmt entregasSmt)
        {
            if (id != entregasSmt.Id)
            {
                return NotFound();
            }
            ModelState.Remove("OrdenTrabajo");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregasSmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregasSmtExists(entregasSmt.Id))
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
            ViewData["OrdenTrabajoId"] = new SelectList(_context.Trabajo, "Id", "Id", entregasSmt.OrdenTrabajoId);
            return View(entregasSmt);
        }

        // GET: EntregasSmt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregasSmt = await _context.EntregasSmt
                .Include(e => e.OrdenTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entregasSmt == null)
            {
                return NotFound();
            }

            return View(entregasSmt);
        }

        // POST: EntregasSmt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entregasSmt = await _context.EntregasSmt.FindAsync(id);
            if (entregasSmt != null)
            {
                _context.EntregasSmt.Remove(entregasSmt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregasSmtExists(int id)
        {
            return _context.EntregasSmt.Any(e => e.Id == id);
        }
    }
}
