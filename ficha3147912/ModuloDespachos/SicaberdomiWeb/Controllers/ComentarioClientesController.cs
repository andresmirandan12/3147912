using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SicaberdomiWeb.Data;
using SicaberdomiWeb.Models;
using Microsoft.AspNetCore.Authorization;





namespace SicaberdomiWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ComentarioClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentarioClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComentarioClientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ComentariosCliente.Include(c => c.Pedido);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ComentarioClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioCliente = await _context.ComentariosCliente
                .Include(c => c.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comentarioCliente == null)
            {
                return NotFound();
            }

            return View(comentarioCliente);
        }

        // GET: ComentarioClientes/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "ClienteId");
            return View();
        }

        // POST: ComentarioClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteNombre,Calificacion,TextoComentario,FechaComentario,PedidoId")] ComentarioCliente comentarioCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarioCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "ClienteId", comentarioCliente.PedidoId);
            return View(comentarioCliente);
        }

        // GET: ComentarioClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioCliente = await _context.ComentariosCliente.FindAsync(id);
            if (comentarioCliente == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "ClienteId", comentarioCliente.PedidoId);
            return View(comentarioCliente);
        }

        // POST: ComentarioClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteNombre,Calificacion,TextoComentario,FechaComentario,PedidoId")] ComentarioCliente comentarioCliente)
        {
            if (id != comentarioCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarioCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioClienteExists(comentarioCliente.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "ClienteId", comentarioCliente.PedidoId);
            return View(comentarioCliente);
        }



        // GET: ComentarioClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarioCliente = await _context.ComentariosCliente
                .Include(c => c.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comentarioCliente == null)
            {
                return NotFound();
            }

            return View(comentarioCliente);
        }

        // POST: ComentarioClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarioCliente = await _context.ComentariosCliente.FindAsync(id);
            if (comentarioCliente != null)
            {
                _context.ComentariosCliente.Remove(comentarioCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioClienteExists(int id)
        {
            return _context.ComentariosCliente.Any(e => e.Id == id);
        }
    }
}
