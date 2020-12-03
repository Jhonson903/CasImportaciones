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
    public class OrdencompraController : Controller
    {
        private readonly CasImportacionesDbContext _context;

        public OrdencompraController(CasImportacionesDbContext context)
        {
            _context = context;
        }

        // GET: Ordencompra
        public async Task<IActionResult> Index()
        {
            var casImportacionesDbContext = _context.Ordencompra.Include(o => o.IdProveedorNavigation).Include(o => o.IdUsuarioNavigation).Include(o => o.ReferenciaNavigation);
            return View(await casImportacionesDbContext.ToListAsync());
        }

        // GET: Ordencompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordencompra = await _context.Ordencompra
                .Include(o => o.IdProveedorNavigation)
                .Include(o => o.IdUsuarioNavigation)
                .Include(o => o.ReferenciaNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (ordencompra == null)
            {
                return NotFound();
            }

            return View(ordencompra);
        }

        // GET: Ordencompra/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor");
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion");
            ViewData["Referencia"] = new SelectList(_context.Producto, "Referencia", "Referencia");
            return View();
        }

        // POST: Ordencompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,Referencia,Cantidad,FechaCompra,IdProveedor,IdUsuario")] Ordencompra ordencompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordencompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor", ordencompra.IdProveedor);
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordencompra.IdUsuario);
            ViewData["Referencia"] = new SelectList(_context.Producto, "Referencia", "Referencia", ordencompra.Referencia);
            return View(ordencompra);
        }

        // GET: Ordencompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordencompra = await _context.Ordencompra.FindAsync(id);
            if (ordencompra == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor", ordencompra.IdProveedor);
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordencompra.IdUsuario);
            ViewData["Referencia"] = new SelectList(_context.Producto, "Referencia", "Referencia", ordencompra.Referencia);
            return View(ordencompra);
        }

        // POST: Ordencompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,Referencia,Cantidad,FechaCompra,IdProveedor,IdUsuario")] Ordencompra ordencompra)
        {
            if (id != ordencompra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordencompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdencompraExists(ordencompra.IdCompra))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "IdProveedor", ordencompra.IdProveedor);
            ViewData["IdUsuario"] = new SelectList(_context.Persona, "IdUsuario", "Direccion", ordencompra.IdUsuario);
            ViewData["Referencia"] = new SelectList(_context.Producto, "Referencia", "Referencia", ordencompra.Referencia);
            return View(ordencompra);
        }

        // GET: Ordencompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordencompra = await _context.Ordencompra
                .Include(o => o.IdProveedorNavigation)
                .Include(o => o.IdUsuarioNavigation)
                .Include(o => o.ReferenciaNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (ordencompra == null)
            {
                return NotFound();
            }

            return View(ordencompra);
        }

        // POST: Ordencompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordencompra = await _context.Ordencompra.FindAsync(id);
            _context.Ordencompra.Remove(ordencompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdencompraExists(int id)
        {
            return _context.Ordencompra.Any(e => e.IdCompra == id);
        }
    }
}
