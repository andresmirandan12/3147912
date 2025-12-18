using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SICABER.Data;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<SICaberDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

// Identity (Usuarios + Roles)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SICaberDbContext>()
    .AddDefaultTokenProviders();

// MVC + Razor
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // 🔥 NO PUEDE FALTAR
app.UseAuthorization();

// Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();   // 🔥 Necesario para Identity

// Crear roles y admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = { "Administrador", "Compras", "Ventas" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    string adminEmail = "admin@sicaber.com";
    string adminPass = "Admin123*";

    var admin = await userManager.FindByEmailAsync(adminEmail);

    if (admin == null)
    {
        admin = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var res = await userManager.CreateAsync(admin, adminPass);
        if (res.Succeeded)
            await userManager.AddToRoleAsync(admin, "Administrador");
    }
}

app.Run();
