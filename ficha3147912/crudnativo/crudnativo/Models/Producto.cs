using System.Data;

namespace crudnativo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
