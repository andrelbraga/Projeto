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
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);

            CreateTable(
                    "dbo.Produto",
                    c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        ImageFile = c.Binary(),
                        ImageMimeType = c.String(maxLength: 200, unicode: false),
                        ImageUrl = c.String(maxLength: 200, unicode: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                        //Categoria_CategoriaId1 = c.Int(),
                        //CategoriaId_CategoriaId = c.Int(),
                        Cliente_ClienteId = c.Int(),
                        //ClienteId_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                //.ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId1)
                //.ForeignKey("dbo.Categoria", t => t.CategoriaId_CategoriaId)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId)
                //.ForeignKey("dbo.Cliente", t => t.ClienteId_ClienteId)
                .Index(t => t.Categoria_CategoriaId)
                //.Index(t => t.Categoria_CategoriaId1)
                //.Index(t => t.CategoriaId_CategoriaId)
                .Index(t => t.Cliente_ClienteId);
                //.Index(t => t.ClienteId_ClienteId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 200, unicode: false),
                        Descricao = c.String(maxLength: 200, unicode: false),
                        status = c.Boolean(nullable: false),
                        CodigoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoId);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperationDate = c.DateTime(nullable: false),
                        Action = c.String(maxLength: 200, unicode: false),
                        User = c.String(maxLength: 200, unicode: false),
                        Machine = c.String(maxLength: 200, unicode: false),
                        Message = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carrinho", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "ClienteId_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Produto", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Produto", "CategoriaId_CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Produto", "Categoria_CategoriaId1", "dbo.Categoria");
            DropForeignKey("dbo.Produto", "Categoria_CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Carrinho", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "ClienteId_ClienteId" });
            DropIndex("dbo.Produto", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Produto", new[] { "CategoriaId_CategoriaId" });
            DropIndex("dbo.Produto", new[] { "Categoria_CategoriaId1" });
            DropIndex("dbo.Produto", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Carrinho", new[] { "ProdutoId" });
            DropIndex("dbo.Carrinho", new[] { "ClienteId" });
            DropTable("dbo.Log");
            DropTable("dbo.Grupo");
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
            DropTable("dbo.Cliente");
            DropTable("dbo.Carrinho");
        }
    }
}
