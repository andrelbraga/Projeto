using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UI.Ecommerce.Models;

namespace WEB.Ecommerce.Models
{
    public partial class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Preencha o Sobreome")]
        //public string Sobrenome { get; set; }

        [EmailAddress(ErrorMessage = "Preencha o Email valido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Preencha o CPF")]
        //public string Cpf { get; set; }

        //public string Celular { get; set; }

        //[Required(ErrorMessage = "Preencha o CEP")]
        //public string Cep { get; set; }

        [DisplayName("Disponivel?")]
        public bool Status { get; set; }
        

        //Classe cliente tem uma coleção de produtos
        public virtual IEnumerable<Produto> Produtos { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}