namespace AndresMiranda.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        // Relación con ventas
        public ICollection<Venta> Ventas { get; set; }
    }
}
