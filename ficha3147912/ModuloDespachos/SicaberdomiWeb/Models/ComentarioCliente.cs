namespace SicaberdomiWeb.Models
{
    public class ComentarioCliente
    {
        public int Id { get; set; }

        public string ClienteNombre { get; set; }

        public int Calificacion { get; set; } // 1 a 5

        public string TextoComentario { get; set; }

        public DateTime FechaComentario { get; set; } = DateTime.Now;

        // 🔗 RELACIÓN CON PEDIDO
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
