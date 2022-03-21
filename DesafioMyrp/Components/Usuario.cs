using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMyrp.Models
{
    public class Usuario
    {
        //nome, idade, telefone, e-mail
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Usuario(string nome, int? idade, string telefone, string email)
        {
            Nome = nome;
            Idade = idade;
            Telefone = telefone;
            Email = email;
        }

        public Usuario()
        {

        }
    }
}