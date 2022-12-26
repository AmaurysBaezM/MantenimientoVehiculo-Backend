using System;
using System.Collections.Generic;
using MantenimientoVehiculoBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MantenimientoVehiculoBackend.Data;

public partial class DbMantenimientoContext : DbContext
{
    public DbMantenimientoContext()
    {
    }

    public DbMantenimientoContext(DbContextOptions<DbMantenimientoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Mecanico> Mecanico { get; set; }

    public virtual DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2GC6TIU;Initial Catalog=DbMantenimiento;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("pk_IdCliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteApellido)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ClienteCedula)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ClienteTelefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("pk_idEstado");

            entity.ToTable("Estado");

            entity.Property(e => e.EstadoNombre)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento).HasName("pk_Mantenimiento");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.IdMantenimiento).HasColumnName("idMantenimiento");
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("fk_Estado");

            entity.HasOne(d => d.MecanicoNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.Mecanico)
                .HasConstraintName("fk_Mecanico");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("fk_TipoMantenimiento");

            entity.HasOne(d => d.VehiculoNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.Vehiculo)
                .HasConstraintName("fk_Vehiculo");
        });

        modelBuilder.Entity<Mecanico>(entity =>
        {
            entity.HasKey(e => e.IdMecanico).HasName("pk_IdMecanico");

            entity.ToTable("Mecanico");

            entity.Property(e => e.MecanicoApellido)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MecanicoCedula)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MecanicoNombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MecanicoTelefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoMantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("pk_Tipo");

            entity.ToTable("TipoMantenimiento");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("pk_idUsuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Usuario");
            entity.Property(e => e.UsuarioNombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("pk_IdVehiculo");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Chasis)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.DueñoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.Dueño)
                .HasConstraintName("fk_idCliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
