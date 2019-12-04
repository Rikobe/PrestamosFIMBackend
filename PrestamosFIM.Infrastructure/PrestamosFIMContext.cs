using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrestamosFIM.Core;

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
                entity.HasKey(e => new { e.IdActivo, e.CodigoBarras });

                entity.ToTable("activo", "prestamosfim");

                entity.HasIndex(e => e.CodigoBarras)
                    .HasName("codigoBarras_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdActivo)
                    .HasColumnName("idActivo")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoBarras)
                    .HasColumnName("codigoBarras")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NombreActivo)
                    .IsRequired()
                    .HasColumnName("nombreActivo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo);

                entity.ToTable("prestamo", "prestamosfim");

                entity.HasIndex(e => e.ResponsablePrestamo)
                    .HasName("FK_Responsable_idx");

                entity.HasIndex(e => new { e.CableVideo, e.CableCorriente, e.Proyector, e.Extension, e.CableHdmi })
                    .HasName("FK_Activo_idx");

                entity.Property(e => e.IdPrestamo)
                    .HasColumnName("idPrestamo")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CableCorriente)
                    .HasColumnName("cableCorriente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CableHdmi)
                    .HasColumnName("cableHdmi")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CableVideo)
                    .HasColumnName("cableVideo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera)
                    .HasColumnName("carrera")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolar)
                    .HasColumnName("cicloEscolar")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasColumnName("extension")
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

                entity.Property(e => e.Proyector)
                    .HasColumnName("proyector")
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
