using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UI.Ecommerce.Models;
using WEB.Ecommerce.Models;

namespace WEB.Ecommerce.Data
{
    public class DataContexto : DbContext
    {

        public DataContexto() : base("Ecommerce") { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(200));
        }

        public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
        {
            public ProdutoConfiguration()
            {
                HasKey(x => x.ProdutoId);

                Property(x => x.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                Property(x => x.Descricao)
                    .IsRequired()
                    .HasMaxLength(200);
                //Configuração que aponta para classe de produto e aponta para a Cliente Id
                HasRequired(x => x.Cliente)
                    .WithMany()
                    .HasForeignKey(x => x.ClienteId);
                //Teste para verificar se da para inserir produto sem ter vinculo com Cliente

            }
        }

        public class CarrinhoConfiguration : EntityTypeConfiguration<Carrinho>
        {
            public CarrinhoConfiguration()
            {
                HasKey(x => x.CarrinhoId);

                HasRequired(x => x.Cliente)
                    .WithMany()
                    .HasForeignKey(x => x.ClienteId);

                HasRequired(x => x.Produto)
                    .WithMany()
                    .HasForeignKey(x => x.ProdutoId);


            }
        }

        public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
        {
            public ClienteConfiguration()
            {
                HasKey(x => x.ClienteId);

                Property(x => x.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                Property(x => x.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(50);

                Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(50);



            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }


    }
}