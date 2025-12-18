using crudnativo.Data;
using crudnativo.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudnativo.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductoController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> ListaProductos = _context.Productos;

            return View();
        }

        //Create GET
        public IActionResult Create()
        {
            return View();
        }

        //Create POST
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        //HTTP GET - EDITAR
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        //HTTP POST - EDITAR
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        //HTTP GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        //HTTP POST - DELETE
        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }
    }

}
