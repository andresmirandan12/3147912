using System.ComponentModel.DataAnnotations;

namespace SICABER.Models
{
    public class CategoriaInsumo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;
    }
}
