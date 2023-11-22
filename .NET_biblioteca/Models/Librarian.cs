using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_biblioteca.Models
{
    public class Librarian
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Endereço")]
        public string Address {get; set; }

        [Display(Name = "Telefone")]
        public int Phone { get; set; }

        [Display(Name = "Membros")]
        public virtual ICollection<Member>? Members { get; set; }

        [Display(Name = "Livros")]
        public virtual ICollection<Book>? Books { get; set; }

        [Display(Name = "Alertas")]
        public virtual ICollection<Alert>? Alerts { get; set; }
    }
}