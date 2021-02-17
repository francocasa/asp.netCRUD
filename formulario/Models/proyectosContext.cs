using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace formulario.Models
{
    public partial class proyectosContext : DbContext
    {
        public proyectosContext()
        {
        }

        public proyectosContext(DbContextOptions<proyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Formulario> Formularios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.ToTable("formulario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
