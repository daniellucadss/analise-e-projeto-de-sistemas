using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_biblioteca.Models
{
    public class Alert
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome do Livro")]
        public string BookName { get; set; }

        [Display(Name = "Data de Emissão")]
        public DateTime IssueDate = DateTime.Now;

        [Display(Name = "Data de Retorno")]
        public DateTime ReturnDate = DateTime.Now.AddDays(30);

        [Display(Name = "Multa")]
        public int Fine { get; set; }
    }
}