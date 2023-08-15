using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BD_Materias.Models;

public partial class BdmateriasContext : DbContext
{
    public BdmateriasContext()
    {
    }

    public BdmateriasContext(DbContextOptions<BdmateriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<RegistroMateria> RegistroMaterias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC27C3C8A2DA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaInscripcion).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC2753E4AE7B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescripcionMateria).HasColumnType("text");
            entity.Property(e => e.Horario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Materia)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("FK__Materias__Profes__286302EC");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC27FBBA558B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RegistroMateria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registro__3214EC279F564B8E");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.RegistroMateria)
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__RegistroM__Estud__2B3F6F97");

            entity.HasOne(d => d.Materia).WithMany(p => p.RegistroMateria)
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("FK__RegistroM__Mater__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
