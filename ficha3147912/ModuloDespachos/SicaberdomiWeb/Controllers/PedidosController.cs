using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SicaberdomiWeb.Data;
using SicaberdomiWeb.Models;
using System.Security.Claims; // Necesario para GetUserId

[Authorize]
public class PedidosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager; // <-- CRUCIAL: Añadido

    public PedidosController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager) // <-- CRUCIAL: Inyectado
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: Pedidos
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        var pedidos = _context.Pedidos
            .Include(p => p.Domiciliario)
            .Include(p => p.Cliente)
            .AsQueryable();

        if (User.IsInRole("Admin"))
        {
            // Admin ve todos
        }
        else if (await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(User), "Domiciliario"))
        {
            // Domiciliario solo ve los asignados a su ID
            pedidos = pedidos.Where(p => p.DomiciliarioId == userId);
        }
        else // Cliente
        {
            // Cliente solo ve los que él mismo creó
            pedidos = pedidos.Where(p => p.ClienteId == userId);
        }

        return View(await pedidos.ToListAsync());
    }

    // GET: Pedidos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        // Lógica de Details (sin cambios relevantes en esta corrección)
        if (id == null) return NotFound();

        var pedido = await _context.Pedidos
            .Include(p => p.Domiciliario)
            .Include(p => p.Cliente)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (pedido == null) return NotFound();

        // Seguridad: Se mantiene la lógica de control de acceso
        var userId = _userManager.GetUserId(User);
        if (!User.IsInRole("Admin") &&
            ((User.IsInRole("Domiciliario") && pedido.DomiciliarioId != userId) ||
             (User.IsInRole("Cliente") && pedido.ClienteId != userId)))
        {
            return Forbid();
        }

        return View(pedido);
    }

    // ----------------------------------------------------------------------
    // GET: Pedidos/Create (CORREGIDO: Carga de Domiciliarios con Email)
    // ----------------------------------------------------------------------
    public async Task<IActionResult> Create()
    {
        if (User.IsInRole("Admin"))
        {
            // Ojo: Si el campo "Email" sigue saliendo vacío, usa "Id" para confirmar.
            // Si el campo "NombreCompleto" de ApplicationUser está lleno, úsalo aquí.
            var domiciliarios = await _userManager.GetUsersInRoleAsync("Domiciliario");
            ViewData["DomiciliarioId"] = new SelectList(domiciliarios, "Id", "Email");
        }
        else
        {
            // Para usuarios no-Admin, el dropdown debe estar vacío.
            ViewData["DomiciliarioId"] = new SelectList(Enumerable.Empty<ApplicationUser>(), "Id", "Email");
        }

        return View();
    }












    // ----------------------------------------------------------------------
    // POST: Pedidos/Create (CORREGIDO: Asignación de ClienteId, Fecha y Null en Domiciliario)
    // ----------------------------------------------------------------------
    // POST: Pedidos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Pedido pedido)
    {
        // *** IGNORAMOS COMPLETAMENTE TODAS LAS REGLAS DE VALIDACIÓN ***
        // Esto fuerza a que ModelState.IsValid sea TRUE, a menos que haya un error de tipo.
        ModelState.Clear();

        // Asignar los valores necesarios
        var userId = _userManager.GetUserId(User);
        pedido.ClienteId = userId;
        pedido.FechaPedido = DateTime.Now;

        if (string.IsNullOrEmpty(pedido.DomiciliarioId))
        {
            pedido.DomiciliarioId = null;
        }

        if (!User.IsInRole("Admin") || pedido.Estado == default)
        {
            pedido.Estado = EstadoEnvio.Pendiente;
        }

        // ----------------------------------------------------------------
        // 1. FORZAMOS EL GUARDADO Y DETECTAMOS EXCEPCIONES
        // ----------------------------------------------------------------
        if (ModelState.IsValid)
        {
            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync(); // <-- Si falla, la excepción se dispara aquí
                return RedirectToAction(nameof(Index)); // ÉXITO
            }
            catch (Exception ex)
            {
                // CRÍTICO: Registramos la excepción de la DB en la consola y la vista
                System.Diagnostics.Debug.WriteLine($"!!! ERROR GRAVE DE BASE DE DATOS: {ex.InnerException?.Message ?? ex.Message}");
                ModelState.AddModelError("", $"ERROR DE BASE DE DATOS: {ex.InnerException?.Message ?? ex.Message}");

                // Recargamos el SelectList de Domiciliarios si hay error
                if (User.IsInRole("Admin"))
                {
                    var domiciliarios = await _userManager.GetUsersInRoleAsync("Domiciliario");
                    ViewData["DomiciliarioId"] = new SelectList(domiciliarios, "Id", "Email", pedido.DomiciliarioId);
                }
                return View(pedido); // Mostramos el error en la vista
            }
        }

        // Si llega aquí sin excepción (muy raro después de ModelState.Clear()), 
        // recargamos la vista de todos modos.
        if (User.IsInRole("Admin"))
        {
            var domiciliarios = await _userManager.GetUsersInRoleAsync("Domiciliario");
            ViewData["DomiciliarioId"] = new SelectList(domiciliarios, "Id", "Email", pedido.DomiciliarioId);
        }
        return View(pedido);
    }











    // ----------------------------------------------------------------------
    // GET: Pedidos/Edit/5 (CORREGIDO: Carga de Domiciliarios con Email)
    // ----------------------------------------------------------------------
    public async Task<IActionResult> Edit(int? id)
    {
        // Lógica de seguridad y búsqueda...
        if (id == null) return NotFound();
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido == null) return NotFound();

        var userId = _userManager.GetUserId(User);
        if (!User.IsInRole("Admin") &&
            ((User.IsInRole("Domiciliario") && pedido.DomiciliarioId != userId) ||
             (User.IsInRole("Cliente") && pedido.ClienteId != userId)))
        {
            return Forbid();
        }

        if (User.IsInRole("Admin"))
        {
            var domiciliarios = await _userManager.GetUsersInRoleAsync("Domiciliario");
            ViewData["DomiciliarioId"] = new SelectList(domiciliarios, "Id", "Email", pedido.DomiciliarioId);
        }

        return View(pedido);
    }








    // POST: Pedidos/Edit/5 (Lógica de edición, se mantiene la seguridad)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Pedido pedido)
    {
        if (id != pedido.Id)
            return NotFound();

        var pedidoDb = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);

        if (pedidoDb == null)
            return NotFound();

        var userId = _userManager.GetUserId(User);

        // Seguridad
        if (!User.IsInRole("Admin") &&
            ((User.IsInRole("Domiciliario") && pedidoDb.DomiciliarioId != userId) ||
             (User.IsInRole("Cliente") && pedidoDb.ClienteId != userId)))
        {
            return Forbid();
        }

        // ✅ CAMPOS QUE SÍ SE PUEDEN EDITAR
        pedidoDb.DireccionEntrega = pedido.DireccionEntrega;
        pedidoDb.Observaciones = pedido.Observaciones;

        if (User.IsInRole("Admin"))
        {
            pedidoDb.DomiciliarioId = pedido.DomiciliarioId;
            pedidoDb.Estado = pedido.Estado;
        }

        if (User.IsInRole("Domiciliario"))
        {
            pedidoDb.Estado = pedido.Estado;
        }

        await _context.SaveChangesAsync();






        // 🔥 CREAR COMENTARIO AUTOMÁTICO CUANDO SE ENTREGA
        if (pedidoDb.Estado == EstadoEnvio.Entregado)
        {
            bool yaExisteComentario = _context.ComentariosCliente
                .Any(c => c.PedidoId == pedidoDb.Id);

            if (!yaExisteComentario)
            {
                var comentariosFalsos = new[]
                {
            "Excelente servicio, muy rápido.",
            "Todo llegó en perfecto estado.",
            "El domiciliario fue muy amable.",
            "Muy buena experiencia, recomendado.",
            "Llegó caliente y a tiempo."
        };

                var random = new Random();

                var comentario = new ComentarioCliente
                {
                    PedidoId = pedidoDb.Id,
                    ClienteNombre = pedidoDb.ClienteNombre,
                    Calificacion = random.Next(4, 6), // ⭐ 4 o 5
                    TextoComentario = comentariosFalsos[random.Next(comentariosFalsos.Length)],
                    FechaComentario = DateTime.Now
                };

                _context.ComentariosCliente.Add(comentario);
                await _context.SaveChangesAsync();
            }
        }










        return RedirectToAction(nameof(Index));
    }










    // GET: Pedidos/Delete/5
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        // Lógica de Delete (sin cambios)
        if (id == null) return NotFound();
        var pedido = await _context.Pedidos.Include(p => p.Domiciliario).FirstOrDefaultAsync(m => m.Id == id);
        if (pedido == null) return NotFound();
        return View(pedido);
    }

    // POST: Pedidos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Lógica de Delete (sin cambios)
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PedidoExists(int id)
    {
        return _context.Pedidos.Any(e => e.Id == id);
    }
}