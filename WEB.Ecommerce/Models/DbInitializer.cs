using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            var clientes = new List<Cliente>
            {
                new Cliente() { Nome = "Andre Braga", Email = "dnk_vip@hotmail.com", Status = true },
                new Cliente() { Nome = "Goku", Email = "Picollo@hotmail.com", Status = true },
                new Cliente() { Nome = "Picollo", Email = "Goku@hotmail.com", Status = true },
                new Cliente() { Nome = "Vegeta", Email = "Vegeta@hotmail.com", Status = true },
                new Cliente() { Nome = "Curirin", Email = "Curirin@hotmail.com", Status = true },
                new Cliente() { Nome = "Kamesama", Email = "Kamesama@hotmail.com", Status = true },
            };

            clientes.ForEach(x => context.Cliente.Add(x));
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto()
                {
                    Nome = "TV",
                    Descricao = "Televisao",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.Single(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.Single(x => x.Nome == "Goku").ClienteId,
                },
                new Produto()
                {
                    Nome = "Geladeira",
                    Descricao = "Geladeira",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.Single(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.Single(x => x.Nome == "Picollo").ClienteId,
                },

                new Produto()
                {
                    Nome = "PS4",
                    Descricao = "Games",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.Single(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.Single(x => x.Nome == "Vegeta").ClienteId,
                },
                new Produto()
                {
                    Nome = "XBOX",
                    Descricao = "Games",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.Single(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.Single(x => x.Nome == "Curirin").ClienteId,
                },

                new Produto()
                {
                    Nome = "Notebook",
                    Descricao = "Informatica",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.Single(x => x.Tipo == "Informatica").CategoriaId,
                    ClienteId = clientes.Single(x => x.Nome == "Kamesama").ClienteId,
                },
            };

            produtos.ForEach(x => context.Produto.Add(x));
            context.SaveChanges();
            //InitializeDatabase(context);

        }
    }
}