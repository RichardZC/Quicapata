using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dominio
{
    public partial class QUICAPATAContext : DbContext
    {
        public QUICAPATAContext()
        {
        }

        public QUICAPATAContext(DbContextOptions<QUICAPATAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empadronado> Empadronado { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=connectionDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empadronado>(entity =>
            {
                entity.Property(e => e.ApeMaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApePaterno)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Conyugue)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ConyugueCelular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConyugueDni)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionReferencia)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Lote)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Manzana)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Completo");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
