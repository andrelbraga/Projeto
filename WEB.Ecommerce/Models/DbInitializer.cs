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
                new Categoria() { Tipo = "Eletrodoméstico", Descricao = "Aparelhos elétricos voltados para facilitar tarefas domsticas."},
                new Categoria() { Tipo = "Vestuario", Descricao = "Produtos voltados para vestimenta, incluindo calçados e acessórios em geral"},
                new Categoria() { Tipo = "Filmes e Seriados", Descricao = "Secção voltada para produtos cinematograficos entre eles fitas, DVDs e boxes"},
                new Categoria() { Tipo = "Games", Descricao = "Produtos de jogos eletronicos "},
                new Categoria() { Tipo = "Produtos musicais", Descricao = "Secção voltada para musica incluindo CDs,instrumentos e acessorios para instumentos"},
                new Categoria() { Tipo = "Livros", Descricao = "Secção voltada para livros, apostila e audio book"},
                new Categoria() { Tipo = "Moveis e Decorações", Descricao = "Secção voltada para moveis e decorações em geral"},
                new Categoria() { Tipo = "Carro,Motos e Automoveis", Descricao = "Secção voltada para objetos detinados para automoveis "},
                new Categoria() { Tipo = "Brinquedos e Hobbies", Descricao = "Secção voltadada para brinquedos e objetos para divesão em geral"},
            };

            categorias.ForEach(x => context.Categoria.Add(x));
            context.SaveChanges();

            //Produtos
            var produtos = new Produto()
            {

            };

            //Clientes
            var clientes = new Cliente()
            {

            };


        }
    }
}