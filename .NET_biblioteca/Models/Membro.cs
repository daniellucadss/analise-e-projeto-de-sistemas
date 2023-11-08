using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Membro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Contato {get; set;}
        public virtual ICollection<Livros>? Livros {get; set;}
        public virtual ICollection<Bibliotecario>? Bibliotecario {get; set;}
    }
}
