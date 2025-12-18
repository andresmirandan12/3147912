using Microsoft.AspNetCore.Identity;
using System.Collections.Generic; // Asegúrate de incluir esto

namespace SicaberdomiWeb.Models
{
    // Usaremos esto para registrar la información de Domiciliario y Cliente Creador
    public class ApplicationUser : IdentityUser
    {
        public string? NombreCompleto { get; set; }
        public bool EstaDisponible { get; set; }

        // ----------------------------------------------------
        // COLECCIONES CORREGIDAS PARA EVITAR AMBIGÜEDAD EN EF CORE
        // ----------------------------------------------------

        // Relación 1: Pedidos donde este usuario es el Domiciliario (Clave Foránea: Pedido.DomiciliarioId)
        public ICollection<Pedido>? PedidosComoDomiciliario { get; set; }

        // Relación 2: Pedidos donde este usuario es el Creador (Clave Foránea: Pedido.ClienteId)
        public ICollection<Pedido>? PedidosComoCliente { get; set; }
    }
}