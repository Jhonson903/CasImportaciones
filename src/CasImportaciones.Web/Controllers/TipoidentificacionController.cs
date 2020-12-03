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
    public class TipoidentificacionController : Controller
    {
        private readonly CasImportacionesDbContext _context;

        public TipoidentificacionController(CasImportacionesDbContext context)
        {
            _context = context;
        }

        // GET: Tipoidentificacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoidentificacion.ToListAsync());
        }

        // GET: Tipoidentificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoidentificacion = await _context.Tipoidentificacion
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoidentificacion == null)
            {
                return NotFound();
            }

            return View(tipoidentificacion);
        }

        // GET: Tipoidentificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoidentificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,Descripcion")] Tipoidentificacion tipoidentificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoidentificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoidentificacion);
        }

        // GET: Tipoidentificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoidentificacion = await _context.Tipoidentificacion.FindAsync(id);
            if (tipoidentificacion == null)
            {
                return NotFound();
            }
            return View(tipoidentificacion);
        }

        // POST: Tipoidentificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,Descripcion")] Tipoidentificacion tipoidentificacion)
        {
            if (id != tipoidentificacion.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoidentificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoidentificacionExists(tipoidentificacion.IdTipo))
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
            return View(tipoidentificacion);
        }

        // GET: Tipoidentificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoidentificacion = await _context.Tipoidentificacion
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoidentificacion == null)
            {
                return NotFound();
            }

            return View(tipoidentificacion);
        }

        // POST: Tipoidentificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoidentificacion = await _context.Tipoidentificacion.FindAsync(id);
            _context.Tipoidentificacion.Remove(tipoidentificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoidentificacionExists(int id)
        {
            return _context.Tipoidentificacion.Any(e => e.IdTipo == id);
        }
    }
}
