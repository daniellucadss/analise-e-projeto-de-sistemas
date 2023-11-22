using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_biblioteca.Models
{
    public class Catalog
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome do Autor")]
        public string AuthorName {get; set; }

        [Display(Name = "Número de Cópias")]
        public int NumberOfCopies { get; set; }

        [Display(Name = "Livros")]
        public virtual ICollection<Book>? Books { get; set; }
    }
}