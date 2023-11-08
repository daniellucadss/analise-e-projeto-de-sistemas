using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string NomeAutor { get; set; }
        public string NomeLivro { get; set; }
        public int QuantidadeLivro { get; set; }
        public virtual Catalogo? Catalogo { get; set; }
        public virtual Bibliotecario? Bibliotecario {get; set;}
    }
}