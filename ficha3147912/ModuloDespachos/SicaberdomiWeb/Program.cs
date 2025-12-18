using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SicaberdomiWeb.Data;
using SicaberdomiWeb.Models; // Importar el namespace de tus modelos

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// *********************************************************************************
// CAMBIO CLAVE: Cambiar IdentityUser por ApplicationUser y añadir AddRoles
// *********************************************************************************
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // IMPORTANTE: Agrega esta línea para soporte de roles
    .AddEntityFrameworkStores<ApplicationDbContext>();
// *********************************************************************************


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// ... (resto del pipeline es correcto) ...

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


// ** 1. Configuración de Roles y Usuarios Iniciales **
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // *********************************************************************************
        // CAMBIO CLAVE: Usar ApplicationUser en GetRequiredService
        // *********************************************************************************
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear Roles
        string[] roleNames = { "Admin", "Domiciliario" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Crear Usuario Administrador de Prueba
        // *********************************************************************************
        // CAMBIO CLAVE: Crear una instancia de ApplicationUser
        // *********************************************************************************
        var adminUser = new ApplicationUser
        {
            UserName = "admin@sicaberdomi.com",
            Email = "admin@sicaberdomi.com",
            EmailConfirmed = true,
            NombreCompleto = "Administrador Principal" // Inicializar campos personalizados
        };

        if (userManager.FindByEmailAsync(adminUser.Email).Result == null)
        {
            var result = await userManager.CreateAsync(adminUser, "Admin123*");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurri un error al seedear la base de datos con roles y usuarios.");
    }
}
// Fin de la configuración de Roles

app.Run();
