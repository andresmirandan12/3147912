using System;
using System.Collections.Generic;

namespace sistemaeducativo12.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
