using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Catalogo
    {
        public int Id { get; set; }
        public string NomeAutor { get; set; }
        public int NumeroCopias { get; set; }
        public virtual ICollection<Livros>? Livros { get; set; }
    }
}