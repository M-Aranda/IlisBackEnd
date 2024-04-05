using ilisBackend.Entities;
using System.Data.Entity.Infrastructure;

namespace ilisBackend.DTO
{
    public class CiudadanoDTO: IDbAsyncEnumerable<Ciudadano>
    {

        public int Id { get; set; }

        public string? Nombre { get; set; }

        public virtual ICollection<AsignacionTarea> AsignacionTareas { get; set; } = new List<AsignacionTarea>();

        public IDbAsyncEnumerator<Ciudadano> GetAsyncEnumerator()
        {
            throw new NotImplementedException();
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
