using Example.Domain.PessoaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class ExampleContext : DbContext
    {
        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.PessoaAggregate.Pessoa> Pessoas { get; set; }
        public DbSet<Domain.CidadeAgreggate.Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
            modelBuilder.Entity<Domain.PessoaAggregate.Pessoa>();

            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfiguration());
            modelBuilder.Entity<Domain.CidadeAgreggate.Cidade>();
        }
    }   

    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PessoaAggregate.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Domain.PessoaAggregate.Pessoa> builder)
        {
            builder.ToTable("Pessoa", "dbo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

             builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.Cpf)
                   .IsRequired()
                   .HasColumnType("varchar(11)");
            
            builder.Property(p => p.Idade).IsRequired();
        }
    }

    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CidadeAgreggate.Cidade>
    {
        public void Configure(EntityTypeBuilder<Domain.CidadeAgreggate.Cidade> builder)
        {
            builder.ToTable("Cidade", "dbo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

             builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");                

            builder.Property(p => p.UF)
                   .IsRequired()
                   .HasColumnType("varchar(2)");          
        }
    }
}
