using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_tw.Models
{
    public partial class easyTalkContext : DbContext
    {
        public easyTalkContext()
        {
        }

        public easyTalkContext(DbContextOptions<easyTalkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=easyTalk;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5A3D0741D6");

                entity.Property(e => e.NomeCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__eventos__AF150CA5C023B5A0");

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.NomeEvento).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__eventos__id_cate__3F466844");

                entity.HasOne(d => d.IdResponsavelNavigation)
                    .WithMany(p => p.EventosIdResponsavelNavigation)
                    .HasForeignKey(d => d.IdResponsavel)
                    .HasConstraintName("FK__eventos__id_resp__412EB0B6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.EventosIdUsuarioNavigation)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__eventos__id_usua__403A8C7D");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipo_usu__CF901089B1AC7AF2");

                entity.Property(e => e.NomeTipoUsuario).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04AD337BE144");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__usuario__AB6E6164C0F1429A")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeUsuario).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.TelefoneMovel).IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__usuario__id_tipo__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
