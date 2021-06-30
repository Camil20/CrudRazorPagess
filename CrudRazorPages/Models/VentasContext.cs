using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CrudRazorPages
{
    public partial class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteSolicitud> ClienteSolicituds { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturasDetalle> FacturasDetalles { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<PagosDetalle> PagosDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Recargo> Recargos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-13989EO;Initial Catalog=Ventas;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ClienteSolicitud>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClienteSolicitud");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId).ValueGeneratedNever();

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facturas_Clientes");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facturas_Estados");
            });

            modelBuilder.Entity<FacturasDetalle>(entity =>
            {
                entity.HasKey(e => e.DetalleId);

                entity.ToTable("FacturasDetalle");

                entity.Property(e => e.DetalleId).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PrecioCompra).HasColumnType("money");

                entity.Property(e => e.PrecioVenta).HasColumnType("money");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturasDetalles)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasDetalle_Facturas");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.FacturasDetalles)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturasDetalle_Productos");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPagado).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("fk_idCliente");
            });

            modelBuilder.Entity<PagosDetalle>(entity =>
            {
                entity.HasKey(e => e.PagoDetalleId)
                    .HasName("pk_idPagoDetalle");

                entity.ToTable("PagosDetalle");

                entity.Property(e => e.MontoPagado).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.PagosDetalles)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("fk_idfaactura");

                entity.HasOne(d => d.Pago)
                    .WithMany(p => p.PagosDetalles)
                    .HasForeignKey(d => d.PagoId)
                    .HasConstraintName("fk_id");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Estados");
            });

            modelBuilder.Entity<Recargo>(entity =>
            {
                entity.HasKey(e => e.IdRecargo)
                    .HasName("pk_Id");

                entity.Property(e => e.IdRecargo).ValueGeneratedNever();

                entity.Property(e => e.FechaRecargo).HasColumnType("datetime");

                entity.Property(e => e.MontoPendiente).HasColumnType("money");

                entity.Property(e => e.MontoRecargo).HasColumnType("money");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Recargos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("fk_IdF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
