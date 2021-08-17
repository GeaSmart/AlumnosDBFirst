using AlumnosTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumnosTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController:ControllerBase
    {
        private readonly AlumnosTestContext context;

        public AlumnosController(AlumnosTestContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> Get()
        {
            return await context.Alumnos.Include(x=>x.Matriculas).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            var existe = await context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound($"No existe el alumno con id: {id}");

            return await context.Alumnos.FirstOrDefaultAsync(x=>x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alumno alumno)
        {
            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Alumno alumno)
        {
            var existe = await context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound($"No existe el alumno con id: {id}");

            if (id != alumno.Id)
                return BadRequest("Los id no coinciden");

            context.Alumnos.Update(alumno);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {            
            var existe = await context.Alumnos.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound($"No existe el alumno con id: {id}");

            context.Alumnos.Remove(new Alumno { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
