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
    public class PersonaController : Controller
    {
        private readonly CasImportacionesDbContext _context;

        public PersonaController(CasImportacionesDbContext context)
        {
            _context = context;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            var casImportacionesDbContext = _context.Persona.Include(p => p.IdNavigation).Include(p => p.IdTipoNavigation);
            return View(await casImportacionesDbContext.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.IdNavigation)
                .Include(p => p.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Aspnetusers, "Id", "Id");
            ViewData["IdTipo"] = new SelectList(_context.Tipoidentificacion, "IdTipo", "IdTipo");
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Identificacion,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion,IdTipo,Id")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Aspnetusers, "Id", "Id", persona.Id);
            ViewData["IdTipo"] = new SelectList(_context.Tipoidentificacion, "IdTipo", "IdTipo", persona.IdTipo);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Aspnetusers, "Id", "Id", persona.Id);
            ViewData["IdTipo"] = new SelectList(_context.Tipoidentificacion, "IdTipo", "IdTipo", persona.IdTipo);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Identificacion,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion,IdTipo,Id")] Persona persona)
        {
            if (id != persona.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdUsuario))
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
            ViewData["Id"] = new SelectList(_context.Aspnetusers, "Id", "Id", persona.Id);
            ViewData["IdTipo"] = new SelectList(_context.Tipoidentificacion, "IdTipo", "IdTipo", persona.IdTipo);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.IdNavigation)
                .Include(p => p.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.IdUsuario == id);
        }
    }
}
