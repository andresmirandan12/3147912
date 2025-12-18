using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechNova.Models;

namespace TechNova.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class VentasController : Controller
    {
        private readonly TechNovaContext _context;

        public VentasController(TechNovaContext context)
        {
            _context = context;
        }

        // ============================================================
        // GET: Ventas
        // ============================================================
        public async Task<IActionResult> Index(string searchCliente, DateTime? searchFecha)
        {
            ViewData["CurrentFilterCliente"] = searchCliente;
            ViewData["CurrentFilterFecha"] = searchFecha?.ToString("yyyy-MM-dd");

            var ventas = _context.Ventas.Include(v => v.Cliente).AsQueryable();

            if (!string.IsNullOrEmpty(searchCliente))
                ventas = ventas.Where(v => v.Cliente.Nombre.Contains(searchCliente));

            if (searchFecha.HasValue)
                ventas = ventas.Where(v => v.FechaVenta.Date == searchFecha.Value.Date);

            return View(await ventas.ToListAsync());
        }

        // ============================================================
        // GET: Ventas/Details/5
        // ============================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.VentaId == id);

            if (venta == null) return NotFound();

            ViewBag.Total = venta.DetalleVenta.Sum(d => d.Cantidad * d.PrecioUnitario);

            return View(venta);
        }

        // ============================================================
        // GET: Ventas/Create
        // ============================================================
        public IActionResult Create()
        {
            CargarSelects(0);
            return View();
        }

        // ============================================================
        // POST: Ventas/Create
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ClienteId, int[] ProductoIds, int[] Cantidades)
        {
            if (ProductoIds == null || Cantidades == null || ProductoIds.Length == 0)
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto.");
                CargarSelects(ClienteId);
                return View();
            }

            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);
                if (producto == null)
                {
                    ModelState.AddModelError("", "Producto inválido.");
                    CargarSelects(ClienteId);
                    return View();
                }

                if (producto.Stock < Cantidades[i])
                {
                    ModelState.AddModelError("", $"Stock insuficiente para {producto.Nombre}. Disponible: {producto.Stock}");
                    CargarSelects(ClienteId);
                    return View();
                }
            }

            var venta = new Venta
            {
                ClienteId = ClienteId,
                FechaVenta = DateTime.Now
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            for (int i = 0; i < ProductoIds.Length; i++)
            {
                var producto = await _context.Productos.FindAsync(ProductoIds[i]);

                _context.DetalleVentas.Add(new DetalleVenta
                {
                    VentaId = venta.VentaId,
                    ProductoId = producto.ProductoId,
                    Cantidad = Cantidades[i],
                    PrecioUnitario = producto.Precio
                });

                producto.Stock -= Cantidades[i];
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Venta registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // ============================================================
        // GET: Ventas/Delete/5
        // ============================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var venta = await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVenta)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.VentaId == id);

            if (venta == null) return NotFound();

            ViewBag.Total = venta.DetalleVenta.Sum(d => d.Cantidad * d.PrecioUnitario);

            return View(venta);
        }

        // ============================================================
        // POST: Ventas/Delete/5
        // ============================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.DetalleVenta)
                .FirstOrDefaultAsync(v => v.VentaId == id);

            if (venta == null) return NotFound();

            // Restaurar stock
            foreach (var detalle in venta.DetalleVenta)
            {
                var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                if (producto != null)
                    producto.Stock += detalle.Cantidad;
            }

            _context.DetalleVentas.RemoveRange(venta.DetalleVenta);
            _context.Ventas.Remove(venta);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Venta eliminada y stock restaurado.";
            return RedirectToAction(nameof(Index));
        }

        // ============================================================
        // NUEVO MÉTODO: Eliminar venta directamente desde la lista (AJAX o POST)
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFromList(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.DetalleVenta)
                .FirstOrDefaultAsync(v => v.VentaId == id);

            if (venta == null) return Json(new { success = false, message = "Venta no encontrada." });

            foreach (var detalle in venta.DetalleVenta)
            {
                var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                if (producto != null)
                    producto.Stock += detalle.Cantidad;
            }

            _context.DetalleVentas.RemoveRange(venta.DetalleVenta);
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Venta eliminada correctamente." });
        }

        // ============================================================
        // MÉTODO PRIVADO PARA CARGAR SELECTS EN CASO DE ERROR
        // ============================================================
        private void CargarSelects(int clienteId)
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", clienteId);

            var productos = _context.Productos
                .Where(p => p.Stock > 0)
                .Select(p => new
                {
                    p.ProductoId,
                    Nombre = p.Nombre,
                    p.Stock,
                    p.Precio
                })
                .ToList();

            ViewData["Productos"] = new SelectList(productos, "ProductoId", "Nombre");
            ViewBag.ProductosData = productos;
        }
    }


}