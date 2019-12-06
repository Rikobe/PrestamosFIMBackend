using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrestamosFIM.Core.Entities;

namespace PrestamosFIM.Infrastructure
{
    public partial class PrestamosFIMContext : DbContext
    {
        public PrestamosFIMContext()
        {
        }

        public PrestamosFIMContext(DbContextOptions<PrestamosFIMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activo> Activo { get; set; }
        public virtual DbSet<DetallePrestamo> DetallePrestamo { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Activo>(entity =>
            {
                entity.HasKey(e => e.IdActivo);

                entity.ToTable("activo", "prestamosfim");

                entity.HasIndex(e => e.CodigoBarras)
                    .HasName("codigoBarras_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdActivo)
                    .HasColumnName("idActivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodigoBarras)
                    .IsRequired()
                    .HasColumnName("codigoBarras")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NombreActivo)
                    .IsRequired()
                    .HasColumnName("nombreActivo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePrestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamoDetalle);

                entity.ToTable("detalleprestamo", "prestamosfim");

                entity.HasIndex(e => e.IdActivo)
                    .HasName("FK_Activo_idx");

                entity.HasIndex(e => e.IdPrestamo)
                    .HasName("FK_Prestamo_idx");

                entity.Property(e => e.IdPrestamoDetalle)
                    .HasColumnName("idPrestamoDetalle")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdActivo)
                    .HasColumnName("idActivo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPrestamo)
                    .HasColumnName("idPrestamo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdActivoNavigation)
                    .WithMany(p => p.DetallePrestamo)
                    .HasForeignKey(d => d.IdActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activo");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.DetallePrestamo)
                    .HasForeignKey(d => d.IdPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prestamo");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo);

                entity.ToTable("prestamo", "prestamosfim");

                entity.HasIndex(e => e.ResponsablePrestamo)
                    .HasName("FK_Responsable_idx");

                entity.Property(e => e.IdPrestamo)
                    .HasColumnName("idPrestamo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Carrera)
                    .HasColumnName("carrera")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolar)
                    .HasColumnName("cicloEscolar")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");

                entity.Property(e => e.FechaPrestamo).HasColumnName("fechaPrestamo");

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAlumno)
                    .IsRequired()
                    .HasColumnName("nombreAlumno")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsablePrestamo)
                    .IsRequired()
                    .HasColumnName("responsablePrestamo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("tipoIdentificacion")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UidAlumno)
                    .IsRequired()
                    .HasColumnName("uidAlumno")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario", "prestamosfim");

                entity.HasIndex(e => e.Correo)
                    .HasName("correo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
