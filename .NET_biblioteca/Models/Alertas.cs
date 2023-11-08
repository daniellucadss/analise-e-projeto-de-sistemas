using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Alertas
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeLivro { get; set; }
        public DateTime DataRetorno { get; set; }
        public int Multa { get; set; }
        public virtual Bibliotecario? Bibliotecario {get; set;}
    }
}