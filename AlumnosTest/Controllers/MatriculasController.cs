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
    public class MatriculasController:ControllerBase
    {
        private readonly AlumnosTestContext context;

        public MatriculasController(AlumnosTestContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<List<Matricula>>> Get()
        {
            return await context.Matriculas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Matricula matricula)
        {
            context.Matriculas.Add(matricula);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
