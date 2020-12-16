using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CursoWebApiLibros.Entities;

namespace CursoWebApiLibros.Entities
{
    //entityFramework => Code First
    //entityFramework => Model First
    public class Autor
    {
        public int Id { get; set; }
        [Required]

        public string Nombre { get; set; }

        public List<Libro> Libros { get; set; }
    }
}