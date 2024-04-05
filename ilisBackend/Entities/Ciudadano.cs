using System;
using System.Collections.Generic;

namespace ilisBackend.Entities;

public partial class Ciudadano
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();
}
