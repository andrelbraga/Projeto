using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Ecommerce.Models;
using WEB.Ecommerce.Data;

namespace WEB.Ecommerce.Models
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContexto>
    {
        protected override void Seed(DataContexto context)
        {
            //Tipos de categorias de produto
            var categorias = new List<Categoria>
            {
                new Categoria() { Tipo = "Informatica", Descricao = "Produtos de Tecnologia voltados a area de informatica."},
                new Categoria() { Tipo = "Eletrodomestico", Descricao = "Produtos de eletrodomestico."},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
                new Categoria() { Tipo = "", Descricao = ""},
            };

            categorias.ForEach(x => context.Categoria.Add(x));
            context.SaveChanges();

            //Produtos
            var produtos = new Produto()
            {
                
            };

            //Clientes


        }
    }
}