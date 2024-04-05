using ilisBackend.DTO;
using ilisBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ilisBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : ControllerBase
    {

        private readonly EastviewContext _context;

        public CitizenController(EastviewContext DBContext)
        {
           _context = DBContext;
        }



        [HttpGet("GetCitizens")]
        public async Task<ActionResult<List<CiudadanoDTO>>> Get()
        {
            var List = await _context.Ciudadanos.Select(
                s => new CiudadanoDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre
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



        [HttpPost("RegisterCitizen/{Nombre}")]
        public async Task<HttpStatusCode> RegisterCitizen(String Nombre)
        {
            var entity = new Ciudadano()
            {
                Nombre = Nombre
            };
            _context.Ciudadanos.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpPut("UpdateCitizen")]
        public async Task<HttpStatusCode> UpdateCitizen(Ciudadano Citizen)
        {
            var entity = await _context.Ciudadanos.FirstOrDefaultAsync(s => s.Id == Citizen.Id);
            entity.Nombre = Citizen.Nombre;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        [HttpDelete("DeleteCitizen/{Id}")]
        public async Task<HttpStatusCode> DeleteCitizen(int Id)
        {
            var entity = new Ciudadano()
            {
                Id = Id
            };
            _context.Ciudadanos.Attach(entity);
            _context.Ciudadanos.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }








    }
}
