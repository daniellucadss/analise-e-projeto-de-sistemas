using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace dotNET_biblioteca.Models
{
    public class Member
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        public int Phone { get; set; }

        [Display(Name = "Livros")]
        public virtual ICollection<Book>? Books { get; set; }
    }
}