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
                
                new Categoria() { Tipo = "Informatica", Descricao = "Produtos de Tecnologia voltados a area de informatica.",ImageUrl="/Imagens/Informatica/CategoriaInformatica.jpeg"},
                new Categoria() { Tipo = "Eletrodoméstico", Descricao = "Aparelhos elétricos voltados para facilitar tarefas domsticas.",ImageUrl="/Imagens/Eletrodomesticos/CategoriaEletrodomestico.png"},
                //new Categoria() { Tipo = "Vestuario", Descricao = "Produtos voltados para vestimenta, incluindo calçados e acessórios em geral",ImageUrl=""},
                new Categoria() { Tipo = "Filmes e Seriados", Descricao = "Secção voltada para produtos cinematograficos entre eles fitas, DVDs e boxes",ImageUrl="/Imagens/Filmes/CategoriaFilmes.jpg"},
                new Categoria() { Tipo = "Games", Descricao = "Produtos de jogos eletronicos ",ImageUrl="/Imagens/Games/CategoriaGames.jpeg"},
                new Categoria() { Tipo = "Produtos musicais", Descricao = "Secção voltada para musica incluindo CDs,instrumentos e acessorios para instumentos",ImageUrl="/Imagens/Instrumentos/CategoriaMusica.jpg"},
                new Categoria() { Tipo = "Livros", Descricao = "Secção voltada para livros, apostila e audio book",ImageUrl="/Imagens/Livros/CategoriaLivro.jpeg"},
                new Categoria() { Tipo = "Móveis e Decorações", Descricao = "Secção voltada para moveis e decorações em geral",ImageUrl="/Imagens/Moveis/CategoriaMoveis.jpg"},
                new Categoria() { Tipo = "Carro,Motos e Automoveis", Descricao = "Secção voltada para objetos detinados para automoveis ",ImageUrl="/Imagens/Automoveis/CategoriaAutomovel.jpg"},
                new Categoria() { Tipo = "Brinquedos e Hobbies", Descricao = "Secção voltadada para brinquedos e objetos para divesão em geral",ImageUrl="/Imagens/Brinquedos/CategoriasBrinquedos.jpeg"},
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
            {   new Produto()
                {
                    Nome = "Armario",
                    Descricao = "Armario",
                    Preco = 1200,
                    ImageUrl="/Imagens/Moveis/moveis2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Móveis e Decorações").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Estante",
                    Descricao = "Estante",
                    Preco = 1200,
                    ImageUrl="/Imagens/Moveis/moveis1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Móveis e Decorações").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Coleção percy Jackson",
                    Descricao = "Coleção Percy Jackson",
                    Preco = 1200,
                    ImageUrl="/Imagens/Livros/livros2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Livros").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 

                new Produto()
                {
                    Nome = "Coleção Harry Potter",
                    Descricao = "Coleção Harry Potter",
                    Preco = 1200,
                    ImageUrl="/Imagens/Livros/livros1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Livros").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 

                new Produto()
                {
                    Nome = "Atabaque",
                    Descricao = "Atabaque",
                    Preco = 1200,
                    ImageUrl="/Imagens/Instumentos/instumentos1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Produtos musicais").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 

                new Produto()
                {
                    Nome = "Computador",
                    Descricao = "Computador",
                    Preco = 1200,
                    ImageUrl="/Imagens/Informatica/informatica1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Informatica").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 


                new Produto()
                {
                    Nome = "PS4",
                    Descricao = "PS4",
                    Preco = 1200,
                    ImageUrl="/Imagens/Games/games2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Fifa 17",
                    Descricao = "Fifa 17",
                    Preco = 1200,
                    ImageUrl="/Imagens/Games/games1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Box ER",
                    Descricao = "Box ER",
                    Preco = 1200,
                    ImageUrl="/Imagens/Filmes/filmes2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Filmes e Seriados").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 

                new Produto()
                {
                    Nome = "Box Batman",
                    Descricao = "Box Batman",
                    Preco = 1200,
                    ImageUrl="/Imagens/Filmes/filmes1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Filmes e Seriados").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Forno eletrico",
                    Descricao = "Forno eletrico",
                    Preco = 1200,
                    ImageUrl="/Imagens/Eletrodomesticos/eletrodomestico2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Cafeteira",
                    Descricao = "Cafeteira",
                    Preco = 1200,
                    ImageUrl="/Imagens/Eletrodomesticos/eletrodomesticos.jpg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Moto Infantil",
                    Descricao = "Moto Infantil",
                    Preco = 1200,
                    ImageUrl="/Imagens/Brinquedos/brinquedos2.jpg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Brinquedos e Hobbies").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 
                new Produto()
                {
                    Nome = "Pula pirata",
                    Descricao = "Pula Pirata",
                    Preco = 1200,
                    ImageUrl="/Imagens/Brinquedos/brinquedos1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Brinquedos e Hobbies").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 

                new Produto()
                {
                    Nome = "Carro",
                    Descricao = "Carro",
                    Preco = 1200,
                    ImageUrl="/Imagens/Automoveis/automoveis2.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Carro,Motos e Automoveis").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                }, 


                new Produto()
                {
                    Nome = "Moto",
                    Descricao = "Moto",
                    Preco = 1200,
                    ImageUrl="/Imagens/Automoveis/automoveis1.jpeg",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Carro,Motos e Automoveis").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                },
                new Produto()
                {
                    Nome = "TV",
                    Descricao = "Televisao",
                    Preco = 1200,
                    ImageUrl="",
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Goku").ClienteId,
                },
                new Produto()
                {
                    Nome = "Geladeira",
                    Descricao = "Geladeira",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Eletrodoméstico").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Picollo").ClienteId,
                },

                new Produto()
                {
                    Nome = "PS4",
                    Descricao = "Games",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Vegeta").ClienteId,
                },
                new Produto()
                {
                    Nome = "XBOX",
                    Descricao = "Games",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Games").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Curirin").ClienteId,
                },

                new Produto()
                {
                    Nome = "Notebook",
                    Descricao = "Informatica",
                    Preco = 1200,
                    Status = true,
                    CategoriaId = categorias.SingleOrDefault(x => x.Tipo == "Informatica").CategoriaId,
                    ClienteId = clientes.SingleOrDefault(x => x.Nome == "Kamesama").ClienteId,
                },
            };

            produtos.ForEach(x => context.Produto.Add(x));
            context.SaveChanges();
            //InitializeDatabase(context);

        }
    }
}