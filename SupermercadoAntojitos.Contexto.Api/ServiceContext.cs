using Microsoft.EntityFrameworkCore;
using SupermercadoAntojitos.Entities.Api;
using SupermercadoAntojitos.Entitiess.Api;

namespace SupermercadoAntojitos.Contexto.Api
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to
    /// </summary>
    public class ServiceContext : DbContext
    {
        /// <summary>
        /// Crea una nueva instancia de la clase
        /// </summary>
        /// <param name="options">Parámeto</param>
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// </summary>
        /// <param name="modelBuilder">Provides a simple API surface for configuring a Microsoft.EntityFrameworkCore.Metadata.IMutableModel</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var venta = modelBuilder.Entity<Venta>();
            venta.ToTable("Venta");
            venta.HasKey(x => x.Id).HasName("PK__VENTA__4BD51FA53F029E7A");
            venta.Property(x => x.ValorPagar).HasColumnType("numeric(18,0)").IsRequired();
            venta.Property(x => x.UnidadesPorProducto).HasColumnType("numeric(18,0)").IsRequired();
            venta.Property(x => x.FechaVenta).IsRequired();

            venta.HasOne(x => x.Clientes).WithMany(x => x.Ventas).HasForeignKey(x => x.IdCliente).OnDelete(DeleteBehavior.NoAction);

            var cliente = modelBuilder.Entity<Cliente>();
            cliente.ToTable("Cliente");
            cliente.HasKey(x => x.Id).HasName("PK__CLIENTE__4BD51FA53F029E7A");
            cliente.Property(x => x.Nombres).HasColumnType("varchar(64)").IsRequired();
            cliente.Property(x => x.DocumentoIdentidad).HasColumnType("numeric(18,0)").IsRequired();
            cliente.Property(x => x.FechaCreacion).IsRequired();

            var producto = modelBuilder.Entity<Producto>();
            producto.ToTable("Producto");
            producto.HasKey(x => x.Id).HasName("PK__PRODUCTO__4BD51FA53F029E7A");
            producto.Property(x => x.NombreProducto).HasColumnType("varchar(64)").IsRequired();
            producto.Property(x => x.Descripcion).HasColumnType("varchar(512)");
            producto.Property(x => x.UnidadesExistentes).HasColumnType("numeric(18,0)").IsRequired();
            producto.Property(x => x.ValorProducto).HasColumnType("numeric(18,0)").IsRequired();

            producto.HasOne(x => x.Ventas).WithMany(x => x.Productos).HasForeignKey(x => x.IdVenta).OnDelete(DeleteBehavior.NoAction);
        }

        /// <summary>
        ///  Gets or Sets DbSet Clientes
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
        /// <summary>
        ///  Gets or Sets DbSet Ventas
        /// </summary>
        public DbSet<Venta> Ventas { get; set; }
        /// <summary>
        ///  Gets or Sets DbSet Producto
        /// </summary>
        public DbSet<Producto> Producto { get; set; }
    }
}
