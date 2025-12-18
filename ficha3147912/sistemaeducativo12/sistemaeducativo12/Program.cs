using Microsoft.EntityFrameworkCore;
using sistemaeducativo12.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//conexion a la base de datos
builder.Services.AddDbContext<SistemaeducativoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SistemaeducativoContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();//agregar esta linea para que funcione la autenticacion


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();//agregar esta linea para que funcione la autenticacion

app.Run();
