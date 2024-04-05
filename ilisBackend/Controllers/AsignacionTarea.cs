using ilisBackend.DTO;
using ilisBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ilisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionTarea : ControllerBase
    {

        private readonly EastviewContext _context;

        public AsignacionTarea(EastviewContext DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("GetAssignatedTasks")]
        public async Task<ActionResult<List<AsignacionTareaDTO>>> Get()
        {
            var List = await _context.AsignacionTareas.Select(
                s => new AsignacionTareaDTO
                {
                    Id = s.Id,
                    IdCiudadano = s.IdCiudadano,
                    IdTarea = s.IdTarea,
                    IdCiudadanoNavigation = s.IdCiudadanoNavigation,
                    IdTareaNavigation = s.IdTareaNavigation


                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }


       




    }
}
