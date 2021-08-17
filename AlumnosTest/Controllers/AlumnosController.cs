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
            return await context.Alumnos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Alumno alumno)
        {
            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
