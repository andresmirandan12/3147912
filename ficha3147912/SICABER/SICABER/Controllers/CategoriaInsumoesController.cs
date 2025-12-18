using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SICABER.Data;
using SICABER.Models;

namespace SICABER.Controllers
{
    public class CategoriaInsumoesController : Controller
    {
        private readonly SICaberDbContext _context;

        public CategoriaInsumoesController(SICaberDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaInsumoes
        public async Task<IActionResult> Index(string buscar)
        {
            var query = _context.CategoriaInsumos.AsQueryable();

            if (!string.IsNullOrEmpty(buscar))
                query = query.Where(c => c.Nombre.Contains(buscar));

            return View(await query.ToListAsync());
        }

        // GET: CategoriaInsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _context.CategoriaInsumos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // GET: CategoriaInsumoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaInsumoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaInsumo categoriaInsumo)
        {
            // Validar duplicado por nombre
            if (_context.CategoriaInsumos.Any(c => c.Nombre == categoriaInsumo.Nombre))
            {
                ModelState.AddModelError("Nombre", "Ya existe una categoría con ese nombre.");
                return View(categoriaInsumo);
            }

            if (ModelState.IsValid)
            {
                categoriaInsumo.Activo = true; // Por defecto activa
                _context.Add(categoriaInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoriaInsumo);
        }

        // GET: CategoriaInsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _context.CategoriaInsumos.FindAsync(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // POST: CategoriaInsumoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaInsumo categoriaInsumo)
        {
            if (id != categoriaInsumo.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoriaInsumo);

            try
            {
                _context.Update(categoriaInsumo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaInsumoExists(categoriaInsumo.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoriaInsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _context.CategoriaInsumos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // POST: CategoriaInsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.CategoriaInsumos.FindAsync(id);

            if (categoria != null)
            {
                _context.CategoriaInsumos.Remove(categoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // CAMBIAR ESTADO (Activo / Inactivo)
        public async Task<IActionResult> CambiarEstado(int id)
        {
            var categoriaActual = await _context.CategoriaInsumos
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoriaActual == null)
                return NotFound();

            categoriaActual.Activo = !(bool)categoriaActual.Activo;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaInsumoExists(int id)
        {
            return _context.CategoriaInsumos.Any(e => e.Id == id);
        }
    }
}
