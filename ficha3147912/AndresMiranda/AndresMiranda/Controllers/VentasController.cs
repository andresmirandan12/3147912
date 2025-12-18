using AndresMiranda.Models;
using AndresMiranda.Data;
using AndresMiranda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crudnativo.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ventas = _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto);

            return View(await ventas.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta.Fecha = DateTime.Now;
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", venta.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", venta.ProductoId);

            return View(venta);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null) return NotFound();

            return View(venta);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
