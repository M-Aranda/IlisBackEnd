using ilisBackend.Entities;

namespace ilisBackend.DTO
{
    public class AsignacionTareaDTO
    {

        public int Id { get; set; }

        public int? IdCiudadano { get; set; }

        public int? IdTarea { get; set; }

        public virtual Ciudadano? IdCiudadanoNavigation { get; set; }

        public virtual Tarea? IdTareaNavigation { get; set; }

    }
}
