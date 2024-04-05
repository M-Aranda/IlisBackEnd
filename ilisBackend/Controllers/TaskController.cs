using ilisBackend.DTO;
using ilisBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace ilisBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {


        private readonly EastviewContext _context;

        public TaskController(EastviewContext DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("GetTasks")]
        public async Task<ActionResult<List<TareaDTO>>> Get()
        {
            var List = await _context.Tareas.Select(
                s => new TareaDTO
                {
                    Id = s.Id,
                    DescripcionTarea= s.DescripcionTarea,
                    DiaDeLaSemana = s.DiaDeLaSemana


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


        [HttpGet("GetTasksByWeekDay/{weekDay}")]
        public async Task<ActionResult<List<TareaDTO>>> GetByWeekDay(int weekDay)
        {
            var tasks = await _context.Tareas
                .Where(s => s.DiaDeLaSemana == weekDay) 
                .Select(s => new TareaDTO
                {
                    Id = s.Id,
                    DescripcionTarea = s.DescripcionTarea,
                    DiaDeLaSemana = s.DiaDeLaSemana
                })
                .ToListAsync();

            if (tasks.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return tasks;
            }
        }




        [HttpPost("RegisterTask")]
        public async Task<HttpStatusCode> InsertUser(Tarea task)
        {
            var entity = new Tarea()
            {
                DescripcionTarea = task.DescripcionTarea,
                DiaDeLaSemana = task.DiaDeLaSemana
            };
            _context.Tareas.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpPut("UpdateTask")]
        public async Task<HttpStatusCode> UpdateUser(Tarea task)
        {
            var entity = await _context.Tareas.FirstOrDefaultAsync(s => s.Id == task.Id);
            entity.DescripcionTarea = task.DescripcionTarea;
            entity.DiaDeLaSemana = task.DiaDeLaSemana;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        [HttpDelete("DeleteTask/{Id}")]
        public async Task<HttpStatusCode> DeleteCitizen(int Id)
        {
            var entity = new Tarea()
            {
                Id = Id
            };
            _context.Tareas.Attach(entity);
            _context.Tareas.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }




    }
}
