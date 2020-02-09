using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAuth.Data;
using WebApiAuth.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAuth.Controllers
{
    [Route("api/Pais/{PaisId}/[controller]")]
    public class CiudadController : Controller
    {
        private readonly ApplicationDbContext context;

        public CiudadController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Ciudad> GetAll(int PaisId)
        {
            return context.Ciudads.Where(x => x.PaisId == PaisId).ToList();
        }

        [HttpGet("{id}", Name = "ciudadById")]
        public IActionResult GetById(int id)
        {
            var pais = context.Ciudads.FirstOrDefault(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ciudad ciudad, int PaisId)
        {
            ciudad.PaisId = PaisId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Ciudads.Add(ciudad);
            context.SaveChanges();

            return new CreatedAtRouteResult("ciudadById", new { id = ciudad.Id }, ciudad);
            
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Ciudad ciudad, int id)
        {
            if (ciudad.Id != id)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ciudad = context.Ciudads.FirstOrDefault(x => x.Id == id);

            if (ciudad == null)
            {
                return NotFound();
            }

            context.Ciudads.Remove(ciudad);
            context.SaveChanges();
            return Ok(ciudad);
        }


    } //Fin Controlador
}
