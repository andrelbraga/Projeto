using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Ecommerce.Models
{
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }

        [Required(ErrorMessage = "Preencha o Nome")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Preencha o Email valido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Disponivel?")]
        public bool Status { get; set; }


        //Classe Vendedor tem uma coleção de Clientes
        public virtual IEnumerable<Cliente> Cliente { get; set; }
        //Classe Vendedor tem uma coleção de produtos
        public virtual IEnumerable<Produto> Produto { get; set; }
        //Classe Vendedor tem uma coleção de  mensagens 
        public virtual IEnumerable<Mensagem> Mensagem { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}