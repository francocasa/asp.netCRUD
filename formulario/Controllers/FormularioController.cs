using formulario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace formulario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {

        private readonly proyectosContext proyectosContext;

        public FormularioController(proyectosContext proyectosContext)
        {
            this.proyectosContext = proyectosContext;
        }





        // GET: api/<FormularioController>
        [HttpGet]
        public IEnumerable<Formulario> Get()
        {
            return proyectosContext.Formularios;
        }




        // GET api/<FormularioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await proyectosContext.Formularios.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }


            return Ok(product);
        }




        // POST api/<FormularioController>
        [HttpPost]
        public async Task<HttpStatusCode> PostProduct( Formulario formulario)
        {
            var entity = new Formulario()
            {
                Codigo = formulario.Codigo,
                Nombre = formulario.Nombre,
                Tipo = formulario.Tipo,
                Precio = formulario.Precio
            };

            proyectosContext.Formularios.Add(entity);

            await proyectosContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }




        // PUT api/<FormularioController>/5
        [HttpPut("{id}")]

        public async Task<HttpStatusCode> PutProduct([FromRoute] int id, Formulario product)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }

            var entity = await proyectosContext.Formularios.FirstOrDefaultAsync(s => s.Id == id);

            entity.Nombre = product.Nombre;
            entity.Codigo = product.Codigo;
            entity.Tipo = product.Tipo;
            entity.Precio = product.Precio;

            await proyectosContext.SaveChangesAsync();

            return HttpStatusCode.NoContent;

        }




        // DELETE api/<FormularioController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }

            var product = await proyectosContext.Formularios.FindAsync(id);
            if (product == null)
            {
                return HttpStatusCode.NotFound;
            }

            proyectosContext.Formularios.Remove(product);
            await proyectosContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }




        private bool FormularioExists(int id)
        {
            return proyectosContext.Formularios.Any(e => e.Id == id);
        }
    }
}
