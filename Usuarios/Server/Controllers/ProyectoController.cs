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
    [Route("Proyecto/Controller")]
    public class ProyectoController : ControllerBase
    {
        private readonly dbcontext context;

        public ProyectoController(dbcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Proyecto>>> Get()
        {
            return await context.Projects.Include(x => x.Tareas).ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Proyecto>> Get(int Id)
        {
            Proyecto proyectousuario = await context.Projects.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (proyectousuario == null)
            {

                return NotFound($"No existe el proyecto con id igual a {Id}.");
            }
            return proyectousuario;
        }

        [HttpPost("{id:int}")]

        public async Task<ActionResult<Proyecto>> PostAsync(Proyecto proyectousuario)
        {
            try
            {
                context.Projects.Add(proyectousuario);
                await context.SaveChangesAsync();
                return proyectousuario;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(int id, [FromBody] Proyecto proyectos)
        {
            //bsco un usuario de la clase Proyecto de la tabla proyectos x id

            Proyecto proyectousuario = await context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            //si mi id es null no existe 
            if (proyectousuario == null)
            {
                return NotFound("no existe el estudiante a modificar.");
            }
            //si es correcto puedo modificar todo lo q sigue
            proyectousuario.Titulo = proyectos.Titulo;
            proyectousuario.TecnicaBack = proyectos.TecnicaBack;
            proyectousuario.TecnicaFront = proyectos.TecnicaFront;

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("No es correcto");
            }
            Proyecto proyectousuario = await context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (proyectousuario == null)//parametro de q no puede ser nulo el dato
            {
                return NotFound($"No existe el proyecto con id igual a {id}.");//retorna error
            }

            try
            {
                context.Projects.Remove(proyectousuario);
                await context.SaveChangesAsync();
                return Ok($"el proyecto {proyectousuario.Titulo} ha sido borrado.");//retorna q se borro
            }
            catch (Exception) //se captura la excepcion del try
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }
    }
}

