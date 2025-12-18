using Microsoft.EntityFrameworkCore;

namespace crudnativo.Data
{ 
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Models.Producto> Productos { get; set; }
    }
}
