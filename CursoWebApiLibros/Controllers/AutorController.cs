using System.ComponentModel.Design.Serialization;
using System;
using System.Threading;
using System.Net;
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
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }

         [HttpGet("{id}", Name="ObtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var resultado = context.Autores.FirstOrDefault(x => x.Id == id);
            if(resultado == null)
            {
                return NotFound();
            }
            return resultado;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new{ id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            if(id != autor.Id)
            {
                BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

    }
}