using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.DbUsuarios;

public partial class DbusuariosContext : DbContext
{
    public DbusuariosContext()
    {
    }

    public DbusuariosContext(DbContextOptions<DbusuariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A648DCD266");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fechaNac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
