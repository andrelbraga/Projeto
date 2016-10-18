using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Ecommerce.Models
{
    public class Compra
    {
        public int CompraId { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro{ get; set; }
    }
}