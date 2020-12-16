using CursoWebApiLibros.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApiLibros.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
                options): base(options)
        {
            
        }
        public DbSet<Autor> Autores {get; set;}
    }
}