using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Adicionando DbSets para mapear as tabelas no banco de dados
    public DbSet<CultivosEInsumos> CultivosEInsumos { get; set; }
    public DbSet<Vendas> Vendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações adicionais para as entidades
        modelBuilder.Entity<CultivosEInsumos>(entity =>
        {
            entity.HasKey(e => e.Id);  // Chave Primária para CultivosEInsumos
            entity.Property(e => e.Cultivo).IsRequired();  // Propriedade obrigatória
            entity.Property(e => e.Insumo).IsRequired();   // Propriedade obrigatória
            entity.Property(e => e.Fornecedor).IsRequired();  // Propriedade obrigatória
        });

        modelBuilder.Entity<Vendas>(entity =>
        {
            entity.HasKey(e => e.Id);  // Chave Primária para Vendas
            entity.Property(e => e.Cliente).IsRequired();  // Propriedade obrigatória
            entity.Property(e => e.Produto).IsRequired();  // Propriedade obrigatória
            entity.Property(e => e.FormaDePagamento).IsRequired();  // Propriedade obrigatória
        });
    }
}
