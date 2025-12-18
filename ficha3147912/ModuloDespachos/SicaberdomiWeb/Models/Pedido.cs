using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
// ELIMINADA: using Microsoft.AspNetCore.Mvc; 

namespace SicaberdomiWeb.Models
{
    // ... Tus enums deben estar aquí o en archivos separados

    public class Pedido
    {
        // ------------------ Clave Primaria ------------------
        public int Id { get; set; }

        // ------------------ Campos del Formulario (Validación) ------------------
        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Nombre del Cliente")]
        public string ClienteNombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un producto/servicio.")]
        [Display(Name = "Producto / Servicio")]
        public TipoProducto Producto { get; set; }

        [Required(ErrorMessage = "La dirección de entrega es obligatoria.")]
        [Display(Name = "Dirección de Entrega")]
        public string DireccionEntrega { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        public ComentarioCliente ComentarioCliente { get; set; }


        // ------------------ Campos ASIGNADOS por el Controlador ------------------

        // ELIMINADO: [BindNever]
        [Display(Name = "Fecha de Pedido")]
        public DateTime FechaPedido { get; set; } // [Required] implícito para tipos struct

        // ELIMINADO: [BindNever]
        [Display(Name = "Estado Actual")]
        public EstadoEnvio Estado { get; set; } // [Required] implícito para tipos struct

        // ------------------ Claves Foráneas (IdentityUser) ------------------

        // 1. Domiciliario Asignado: Anulable (string?) y sin [Required]. CORRECTO.
        [Display(Name = "Domiciliario Asignado")]
        public string? DomiciliarioId { get; set; }
        [ForeignKey("DomiciliarioId")]
        public ApplicationUser? Domiciliario { get; set; }


        // 2. Cliente Creador
        // ELIMINADO: [BindNever]
        [Required] // Requerido para la DB
        public string ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public ApplicationUser Cliente { get; set; }
    }
}