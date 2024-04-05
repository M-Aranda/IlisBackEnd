using ilisBackend.Entities;

namespace ilisBackend.DTO
{
    public class TareaDTO
    {
        public int Id { get; set; }

        public string? DescripcionTarea { get; set; }

        public int? DiaDeLaSemana { get; set; }

        public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

    }
}
