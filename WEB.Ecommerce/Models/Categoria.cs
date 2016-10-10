using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Ecommerce.Models
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

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}