using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sistemaeducativo12.Models;

public partial class SistemaeducativoContext : IdentityDbContext
{
    public SistemaeducativoContext()
    {
    }

    public SistemaeducativoContext(DbContextOptions<SistemaeducativoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-EHPGVIE\\SQLEXPRESS;Initial Catalog=sistemaeducativo;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__curso__5D3F75020C1DFD29");

            entity.ToTable("curso");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_curso");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__estudian__E0B2763CD30A525A");

            entity.ToTable("estudiante");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__estudian__7B886A630013EAB5").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PK__matricul__1D7CF00BCA6971F2");

            entity.ToTable("matricula");

            entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");
            entity.Property(e => e.FechaMatricula)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_matricula");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_matricula_curso");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_matricula_estudiante");
            base.OnModelCreating(modelBuilder);//Agregar esta línea para Identity
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
