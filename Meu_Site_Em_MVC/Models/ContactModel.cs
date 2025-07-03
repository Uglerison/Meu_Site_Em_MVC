using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meu_Site_Em_MVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O Campo Nome é OBRIGATÓRIO!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Campo Email é OBRIGATÓRIO!")]
        [EmailAddress(ErrorMessage ="Formato de email inválido! Digite novamente")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo Telefone é OBRIGATÓRIO!")]
        [Phone(ErrorMessage = "Formato de telefone inválido! Digite novamente")]
        public string Phone { get; set; }

    }
}
