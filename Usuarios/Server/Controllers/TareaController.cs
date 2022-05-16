using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Compartidos;
using Usuarios.Compartidos.database;

namespace Usuarios.Server.Controllers
{
    [ApiController]
    [Route("Tarea/Controller")]
    public class TareaController : ControllerBase
    {
        private readonly dbcontext context;

        public TareaController(dbcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> Get()
        {
            return await context.Work.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Tarea>> Get(int Id)
        {
            Tarea tareausuario = await context.Work.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (tareausuario == null)
            {
                return NotFound($"No existe la tarea con id igual a {Id}.");
            }
            return tareausuario;
        }

        [HttpPost("{id:int}")]

        public async Task<ActionResult<Usuario>> PostAsync(Tarea tareausuario)
        {
            try
            {
                context.Work.Add(tareausuario);
                await context.SaveChangesAsync();
                return tareausuario;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tarea tareas)
        {
            Tarea tareausuario = await context.Work.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (tareausuario == null)
            {
                return NotFound("no existe la tarea a modificar.");
            }
            tareausuario.Descripcion = tareas.Descripcion;
            tareausuario.Estado = tareas.Estado;


            try
            {
                context.Work.Remove(tareausuario);
                await context.SaveChangesAsync();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            Tarea tareausuario = await context.Work.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (tareausuario == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe la tarea con id igual a {id}.");//retorna error
            }

            try
            {
                context.Work.Remove(tareausuario);
                await context.SaveChangesAsync();
                return Ok($"el usuario {tareausuario.Descripcion} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }
    }
}
