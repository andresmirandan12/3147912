namespace SicaberdomiWeb.Models
{
    // Este enum define los posibles estados de un pedido
    public enum EstadoEnvio
    {
        Pendiente = 1,      // El pedido ha sido creado, esperando asignación/confirmación
        EnProceso = 2,      // Está siendo preparado o el domiciliario ha aceptado
        EnCamino = 3,       // El domiciliario está en ruta de entrega
        Entregado = 4,      // La entrega se completó
        Cancelado = 5       // El pedido fue anulado
    }
}