namespace WEB.Ecommerce.Migrations.DataContexto
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinho",
                c => new
                    {
                        CarrinhoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarrinhoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .Index(t => t.ClienteId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        Email = c.String(),
                        Cpf = c.String(nullable: false),
                        Celular = c.String(),
                        Cep = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(nullable: false, maxLength: 150),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperationDate = c.DateTime(nullable: false),
                        Action = c.String(),
                        User = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carrinho", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Carrinho", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "ClienteId" });
            DropIndex("dbo.Carrinho", new[] { "ProdutoId" });
            DropIndex("dbo.Carrinho", new[] { "ClienteId" });
            DropTable("dbo.Logs");
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
            DropTable("dbo.Cliente");
            DropTable("dbo.Carrinho");
        }
    }
}
