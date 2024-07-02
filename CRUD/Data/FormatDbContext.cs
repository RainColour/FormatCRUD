using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class FormatDbContext : DbContext
    {
        public FormatDbContext(DbContextOptions<FormatDbContext> options) : base(options) { }

        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Secao> Secoes { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}