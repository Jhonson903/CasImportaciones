using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasImportaciones.Core.Domain;
using CasImportaciones.Infrastructure.Data;

namespace CasImportaciones.Web.Controllers
{
    public class OrdenventaController : Controller
    {
        private readonly CasImportacionesDbContext _context;

        public OrdenventaController(CasImportacionesDbContext context)
        {
            _context = context;
        }

        // GET: Ordenventa
        public async Task<IActionResult> Index()
        {
            var casImportacionesDbContext = _context.Ordenventa.Include(o => o.IdUsuarioNavigation);
            return View(await casImportacionesDbContext.ToListAsync());
        }

        // GET: Ordenventa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenventa = await _context.Ordenventa
                .Include(o => o.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ordenventa == null)
            {
                return NotFound();
            }

            return View(ordenventa);
        }

        // GET: Ordenventa/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion");
            return View();
        }

        // POST: Ordenventa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,FechaVenta,Cantidad,ValorTotal,IdUsuario")] Ordenventa ordenventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordenventa.IdUsuario);
            return View(ordenventa);
        }

        // GET: Ordenventa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenventa = await _context.Ordenventa.FindAsync(id);
            if (ordenventa == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordenventa.IdUsuario);
            return View(ordenventa);
        }

        // POST: Ordenventa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,FechaVenta,Cantidad,ValorTotal,IdUsuario")] Ordenventa ordenventa)
        {
            if (id != ordenventa.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenventaExists(ordenventa.IdVenta))
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
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordenventa.IdUsuario);
            return View(ordenventa);
        }

        // GET: Ordenventa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenventa = await _context.Ordenventa
                .Include(o => o.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ordenventa == null)
            {
                return NotFound();
            }

            return View(ordenventa);
        }

        // POST: Ordenventa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenventa = await _context.Ordenventa.FindAsync(id);
            _context.Ordenventa.Remove(ordenventa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenventaExists(int id)
        {
            return _context.Ordenventa.Any(e => e.IdVenta == id);
        }
    }
}
