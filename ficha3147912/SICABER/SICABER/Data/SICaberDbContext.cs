using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SICABER.Models;

public class SICaberDbContext : IdentityDbContext
{
    public SICaberDbContext(DbContextOptions<SICaberDbContext> options)
        : base(options)
    {
    }

    public DbSet<CategoriaInsumo> CategoriaInsumos { get; set; }
}
