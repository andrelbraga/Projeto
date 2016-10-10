using System.Collections.Generic;
using System.Web.UI;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Migrations.DataContexto
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WEB.Ecommerce.Data.DataContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DataContexto";
        }

        protected override void Seed(WEB.Ecommerce.Data.DataContexto context)
        {
            //Tipos de categorias de produto
            context.Categoria.AddOrUpdate(
                new Categoria
                {
                    Tipo = "Informatica",
                    Descricao = "Produtos de Tecnologia voltados a area de informatica."
                },
                new Categoria
                {
                    Tipo = "Eletrodoméstico",
                    Descricao = "Aparelhos elétricos voltados para facilitar tarefas domsticas."
                },
                new Categoria
                {
                    Tipo = "Vestuario",
                    Descricao = "Produtos voltados para vestimenta, incluindo calçados e acessórios em geral"
                },
                new Categoria
                {
                    Tipo = "Filmes e Seriados",
                    Descricao = "Secção voltada para produtos cinematograficos entre eles fitas, DVDs e boxes"
                },
                new Categoria
                {
                    Tipo = "Games",
                    Descricao = "Produtos de jogos eletronicos "
                },
                new Categoria
                {
                    Tipo = "Produtos musicais",
                    Descricao = "Secção voltada para musica incluindo CDs,instrumentos e acessorios para instumentos"
                },
                new Categoria
                {
                    Tipo = "Livros",
                    Descricao = "Secção voltada para livros, apostila e audio book"
                },
                new Categoria
                {
                    Tipo = "Moveis e Decorações",
                    Descricao = "Secção voltada para moveis e decorações em geral"
                },
                new Categoria
                {
                    Tipo = "Carro,Motos e Automoveis",
                    Descricao = "Secção voltada para objetos detinados para automoveis "
                },
                new Categoria
                {
                    Tipo = "Brinquedos e Hobbies",
                    Descricao = "Secção voltadada para brinquedos e objetos para divesão em geral"
                });


            //Grupo
            context.Grupo.AddOrUpdate(
                new Grupo() {Tipo = "Convidados", Descricao = "Usuarios convidados", status = true, CodigoId = 100},
                new Grupo() {Tipo = "Administrador", Descricao = "Usuarios convidados", status = true, CodigoId = 500},
                new Grupo() {Tipo = "Clientes", Descricao = "Usuarios convidados", status = true, CodigoId = 200}
            );

            //Cliente
            context.Cliente.AddOrUpdate(
                new Cliente
                {
                    Nome = "André Braga",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 2
                },
                new Cliente
                {
                    Nome = "Bill Gates",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 2
                },
                new Cliente
                {
                    Nome = "Ferando Alves",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 1
                },
                new Cliente
                {
                    Nome = "Tomas Roberto",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 1
                },
                new Cliente
                {
                    Nome = "Steve Jobs",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 2
                },
                new Cliente
                {
                    Nome = "Tony Stark",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                    //GrupoId = 2
                },
                new Cliente
                {
                    Nome = "Asa Notui",
                    Email = "dnk_vip@hotmail.com",
                    Status = true,
                   //GrupoId = 2 
                });

    }
        }
    }

