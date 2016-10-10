using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB.Ecommerce.Models
{
    public class Categoria
    {
        public  int CategoriaId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}