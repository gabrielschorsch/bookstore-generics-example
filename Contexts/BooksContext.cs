using System;
using System.Collections.Generic;
using BookStore2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore2.Contexts;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BookStore;Data Source=ESS000N1530612;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autores__DD33B031832EAB0E");

            entity.HasIndex(e => e.Email, "UQ__Autores__A9D10534FC1DE690").IsUnique();

            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Generos__0F8349883EE92670");

            entity.HasIndex(e => e.Descricao, "UQ__Generos__008BA9EF8D6CEF8D").IsUnique();

            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.IdLivro).HasName("PK__Livros__3B69D85AE6E54299");

            entity.HasIndex(e => e.Titulo, "UQ__Livros__7B406B56D2943A62").IsUnique();

            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Livros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__Livros__IdAutor__3F466844");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Livros)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK__Livros__IdGenero__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
