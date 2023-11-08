using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        public DbSet<Alertas> Alertas { get; set; } 
        public DbSet<Bibliotecario> Bibliotecario { get; set; }
        public DbSet<Catalogo> Catalogo { get; set; }
        public DbSet<CorpoDocente> CorpoDocente { get; set; }
        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<LivroGeral> LivroGeral { get; set; }
        public DbSet<LivroReferencia> LivroReferencia { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Livros> Livros { get; set; }
    }
}