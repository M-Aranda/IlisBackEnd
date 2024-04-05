using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ilisBackend.DTO;

namespace ilisBackend.Entities;

public partial class EastviewContext : DbContext
{
    public EastviewContext()
    {
    }

    public EastviewContext(DbContextOptions<EastviewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionTarea> AsignacionTareas { get; set; }

    public virtual DbSet<Ciudadano> Ciudadanos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=EASTVIEW");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionTarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asignacion_tarea");

            entity.HasIndex(e => e.IdCiudadano, "id_ciudadano");

            entity.HasIndex(e => e.IdTarea, "id_tarea");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCiudadano).HasColumnName("id_ciudadano");
            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");

            entity.HasOne(d => d.IdCiudadanoNavigation).WithMany(p => p.AsignacionTareas)
                .HasForeignKey(d => d.IdCiudadano)
                .HasConstraintName("asignacion_tarea_ibfk_1");

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.AsignacionTareas)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("asignacion_tarea_ibfk_2");
        });

        modelBuilder.Entity<Ciudadano>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciudadano");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tarea");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionTarea)
                .HasMaxLength(200)
                .HasColumnName("descripcion_tarea");
            entity.Property(e => e.DiaDeLaSemana).HasColumnName("dia_de_la_semana");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
