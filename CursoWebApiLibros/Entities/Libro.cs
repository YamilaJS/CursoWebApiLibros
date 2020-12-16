using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoWebApiLibros.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; } //propiedad de navegacion

    }
}