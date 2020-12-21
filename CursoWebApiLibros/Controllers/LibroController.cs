using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CursoWebApiLibros.Contexto;
using System.Collections.Generic;
using CursoWebApiLibros.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class LibroController:ControllerBase
    { 
        private readonly ApplicationDbContext context;

        public LibroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.Include(x => x.Autor).ToList();
        }

        [HttpGet("{id}", Name="ObtenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var resultado = context.Libros.Include(x => x.Autor).FirstOrDefault(x => x.Id == id);
            if(resultado == null)
            {
                return NotFound();
            }
            return resultado;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            context.Libros.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new{ id = libro.Id }, libro);
        }
        

    }
}