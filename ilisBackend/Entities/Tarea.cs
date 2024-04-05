using System;
using System.Collections.Generic;

namespace ilisBackend.Entities;

public partial class Tarea
{
    public int Id { get; set; }

    public string? DescripcionTarea { get; set; }

    public int? DiaDeLaSemana { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();
}
