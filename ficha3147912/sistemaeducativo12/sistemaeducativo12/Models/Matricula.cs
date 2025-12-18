using System;
using System.Collections.Generic;

namespace sistemaeducativo12.Models;

public partial class Matricula
{
    public int IdMatricula { get; set; }

    public int IdEstudiante { get; set; }

    public int IdCurso { get; set; }

    public DateOnly FechaMatricula { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; } = null!;
    
    public virtual Estudiante? IdEstudianteNavigation { get; set; } = null!;
}
