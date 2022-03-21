using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioMyrp.Models
{
    public class Integracao
    {
        public int Id { get; set; }
        
        public bool Nome { get; set; }
      
        public bool Idade { get; set; }
      
        public bool Telefone { get; set; }
     
        public bool Email { get; set; }

        public string Campo { get; set; }
        public string Condicao { get; set; }
        public int? Valor { get; set; }

        [Required, StringLength(20)]
        public string Formato { get; set; }        

        [Required, StringLength(20)]
        public string Acao { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [Required, StringLength(10)]
        public string MetodoRequisicao { get; set; }

        [Required, StringLength(100)]
        public string Url { get; set; }

        public Integracao(int id, bool nome, bool idade, bool telefone, bool email, string formato, string campo, string condicao, int? valor, string acao, string titulo, string metodoRequisicao)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Telefone = telefone;
            Email = email;
            Formato = formato;
            Campo = campo;
            Condicao = condicao;
            Valor = valor;
            Acao = acao;
            Titulo = titulo;
            MetodoRequisicao = metodoRequisicao;
        }

        public Integracao()
        {

        }
    }
}