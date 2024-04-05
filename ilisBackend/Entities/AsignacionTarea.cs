using System;
using System.Collections.Generic;

namespace ilisBackend.Entities;

public partial class AsignacionTarea
{
    public int Id { get; set; }

    public int? IdCiudadano { get; set; }

    public int? IdTarea { get; set; }

    public virtual Ciudadano? IdCiudadanoNavigation { get; set; }

    public virtual Tarea? IdTareaNavigation { get; set; }
}
