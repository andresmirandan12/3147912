namespace AndresMiranda.Models
{

    public class Venta
    {
        public int Id { get; set; }

        // FK Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // FK Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
