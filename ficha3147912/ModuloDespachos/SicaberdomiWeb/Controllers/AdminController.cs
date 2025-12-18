using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicaberdomiWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // [Dashboard]
    public IActionResult Index()
    {
        return View();
    }

    // [CRUD - READ]: Muestra la lista de Domiciliarios
    public async Task<IActionResult> Domiciliarios()
    {
        var domiciliarios = await _userManager.GetUsersInRoleAsync("Domiciliario");
        return View(domiciliarios);
    }

    // ====================================================================
    // [CRUD - UPDATE]: EDITAR DOMICILIARIO
    // ====================================================================

    // GET: Muestra el formulario de edición
    public async Task<IActionResult> EditDomiciliario(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // Verifica que el usuario tenga el rol "Domiciliario" (seguridad adicional)
        if (!await _userManager.IsInRoleAsync(user, "Domiciliario"))
        {
            return Unauthorized();
        }

        return View(user);
    }

    // POST: Procesa el envío del formulario de edición
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditDomiciliario(string id, ApplicationUser model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.NombreCompleto = model.NombreCompleto;
            user.EstaDisponible = model.EstaDisponible;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Domiciliarios));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        return View(model);
    }

    // ====================================================================
    // [CRUD - DELETE]: ELIMINAR DOMICILIARIO
    // ====================================================================

    // GET: Muestra la vista de confirmación de eliminación
    public async Task<IActionResult> DeleteDomiciliario(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: Procesa la eliminación
    [HttpPost, ActionName("DeleteDomiciliario")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Domiciliarios));
            }
        }
        return RedirectToAction(nameof(Domiciliarios));
    }
}