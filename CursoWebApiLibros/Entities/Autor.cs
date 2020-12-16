using System.ComponentModel.DataAnnotations;

namespace CursoWebApiLibros.Entities
{
    //entityFramework => Code First
    //entityFramework => Model First
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}