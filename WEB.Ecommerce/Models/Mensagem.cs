using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB.Ecommerce.Models
{
    public class Mensagem
    {
        [Key]
        public int MensagenId { get; set; }

        [DisplayName("Assunto :")]
        public string Titulo { get; set; }

        [DisplayName("Texto :")]
        public string Texto { get; set; }

        //Cliente para sobrescrever lazyload
        [ScaffoldColumn(false)]
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public int VendedorId { get; set; }

        [ScaffoldColumn(false)]
        public int ProdutoId { get; set; }

        public IEnumerable<Vendedor> Vendedor { get; set; }
        public IEnumerable<Cliente> Cliente { get; set; }

        public virtual Produto Produto { get; set; }

    }
}