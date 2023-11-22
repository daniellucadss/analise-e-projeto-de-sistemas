using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_biblioteca.Models
{
    public class Book
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Nome do Autor")]
        public string AuthorName { get; set; }

        [Display(Name = "Número de Livros")]
        public int NumberOfBooks { get; set; }

        [Display(Name = "Catálogo")]
        public virtual Catalog? Catalog { get; set; }
    }
}