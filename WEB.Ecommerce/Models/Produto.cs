using System;
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
        public String ImageUrl { get; set; }

        [Range(typeof(decimal), "0", "9999999999999")]
        [Required(ErrorMessage = "Preencha um Valor")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        //Para verificar se produto está disponivel
        [DisplayName("Disponivel?")]
        public bool Status { get; set; }

        

        //Cliente para sobrescrever lazyload
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}