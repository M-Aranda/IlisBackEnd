using ilisBackend.DTO;
using ilisBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ilisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionTareaController : ControllerBase
    {

        private readonly EastviewContext _context;

        public AsignacionTareaController(EastviewContext DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("GetAssignatedTasks")]
        public async Task<ActionResult<List<AsignacionTareaDTO>>> Get()
        {
            var List = await _context.AsignacionTareas.Select(
                assignment => new AsignacionTareaDTO
                {
                    Id = assignment.Id,
                    IdCiudadano = assignment.IdCiudadano,
                    IdTarea = assignment.IdTarea,
                    IdCiudadanoNavigation = assignment.IdCiudadanoNavigation,
                    IdTareaNavigation = assignment.IdTareaNavigation


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


        [HttpPost("AssignTask")]
        public async Task<HttpStatusCode> InsertUser(AsignacionTarea assignment)
        {
            var entity = new AsignacionTarea()
            {
                Id = assignment.Id,
                IdCiudadano = assignment.IdCiudadano,
                IdTarea = assignment.IdTarea,
                IdCiudadanoNavigation = assignment.IdCiudadanoNavigation,
                IdTareaNavigation = assignment.IdTareaNavigation
            };
            _context.AsignacionTareas.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }










    }
}
