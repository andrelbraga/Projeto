using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Ecommerce.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Display(Name = "Upload image")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Image link")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Range(typeof(decimal), "0", "9999999999999")]
        [Required(ErrorMessage = "Preencha um Valor")]
        public decimal Preco { get; set; }

        //Para verificar se produto está disponivel
        [DisplayName("Disponivel?")]
        public bool Status { get; set; }

        [DisplayName("Categoria do Produto")]
        public int CategoriaId { get; set; }

        //Classes que serão sobrescritas
        //public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        //public virtual Mensagem Mensagem { get; set; }
        public virtual Categoria Categoria { get; set; }

        //Grava Id Cliente no momento ca Compra
        //[ScaffoldColumn(false)]
        //public int ClienteId { get; set; }

        //Grava Id no momento do Input do vendedor
        [ScaffoldColumn(false)]
        public int VendedorId { get; set; }

        //Grava Id da mensagem associada ao produto
        //[ScaffoldColumn(false)]
        //public int MensagenId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        
    }
}