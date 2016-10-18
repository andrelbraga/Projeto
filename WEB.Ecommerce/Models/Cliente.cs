using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Ecommerce.Models
{
    public partial class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [DisplayName("Preencha o Nome")]
        public string Nome { get; set; }

        [DisplayName("Preencha o Sobreome")]
        public string Sobrenome { get; set; }

        [DisplayName("Preencha o CEP")]
        public string Email { get; set; }

        [DisplayName("Preencha o CPF")]
        public string Cpf { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Preencha o CEP")]
        public string Cep { get; set; }

        [DisplayName("Disponivel?")]
        public bool Status { get; set; }
        

        //Classe cliente tem uma coleção de produtos
        public virtual IEnumerable<Produto> Produto { get; set; }
        //Classe Cliente tem uma coleção de Mensagens
        public virtual IEnumerable<Mensagem> Mensagem { get; set; }


        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}