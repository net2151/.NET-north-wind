using ProductCatalog.Domain;
using ProductCatalog.Domain.Outbox;
using ProductCatalog.Views;

namespace ProductCatalog.Data;

public class MainDbContext : AppDbContextBase
{
    private const string Schema = "product_catalog";

    public MainDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<ProductView> ProductViews { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension(Consts.UuidGenerator);

        // product
        modelBuilder.Entity<Product>().ToTable("products", Schema);
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnType("uuid")
            .HasDefaultValueSql(Consts.UuidAlgorithm);

        modelBuilder.Entity<Product>().Property(x => x.Created).HasDefaultValueSql(Consts.DateAlgorithm);

        modelBuilder.Entity<Product>().HasIndex(x => x.Id).IsUnique();
        modelBuilder.Entity<Product>().Ignore(x => x.DomainEvents);

        // category
        modelBuilder.Entity<Category>().ToTable("categories", Schema);
        modelBuilder.Entity<Category>().HasKey(x => x.Id);
        modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnType("uuid")
            .HasDefaultValueSql(Consts.UuidAlgorithm);

        modelBuilder.Entity<Category>().Property(x => x.Created).HasDefaultValueSql(Consts.DateAlgorithm);

        modelBuilder.Entity<Category>().HasIndex(x => x.Id).IsUnique();
        modelBuilder.Entity<Category>().Ignore(x => x.DomainEvents);

        // supplier info
        modelBuilder.Entity<SupplierInfo>().ToTable("suppliers_info", Schema);
        modelBuilder.Entity<SupplierInfo>().HasKey(x => x.Id);
        modelBuilder.Entity<SupplierInfo>().Property(x => x.Id).HasColumnType("uuid")
            .HasDefaultValueSql(Consts.UuidAlgorithm);

        modelBuilder.Entity<SupplierInfo>().Property(x => x.Created);

        modelBuilder.Entity<SupplierInfo>().HasIndex(x => x.Id).IsUnique();

        // relationships
        modelBuilder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<Product>()
            .HasOne(x => x.SupplierInfo);

        // outbox
        modelBuilder.Entity<ProductOutbox>().ToTable("product_outboxes", Schema);
        modelBuilder.Entity<ProductOutbox>().HasKey(x => x.Id);
        modelBuilder.Entity<ProductOutbox>().Property(x => x.Id).HasColumnType("uuid")
            .HasDefaultValueSql(Consts.UuidAlgorithm);

        modelBuilder.Entity<ProductOutbox>().HasIndex(x => x.Id).IsUnique();
        modelBuilder.Entity<ProductOutbox>().Ignore(x => x.Updated);
        modelBuilder.Entity<ProductOutbox>().Ignore(x => x.DomainEvents);

        // views
        modelBuilder.Entity<ProductView>().ToTable("product_views", Schema);
        modelBuilder.Entity<ProductView>().HasKey(x => x.ProductId);
        modelBuilder.Entity<ProductView>().Property(x => x.ProductId).HasColumnType("uuid")
            .HasDefaultValueSql(Consts.UuidAlgorithm);

        modelBuilder.Entity<ProductView>().HasIndex(x => x.ProductId).IsUnique();
    }
}

