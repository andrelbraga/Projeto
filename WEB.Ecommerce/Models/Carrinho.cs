using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB.Ecommerce.Models
{
    public class Carrinho
    {
        public int CarrinhoId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}
/*
 CarrinhoId int not null,
	ClienteId int not null,
	ProdutoId int not null,
	QtdItem int not null,
	DataCadastro DateTime,
	DataOcorrencia DateTime,
	Concorrencia DateTime,

	constraint pk_carrinho primary key (CarrinhoId),
	constraint fk_cliente foreign key (ClienteId) references Cliente(ClienteId),
	constraint fk_produto foreign key (ProdutoId) references Produto(ProdutoId),
     */
