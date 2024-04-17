using System;
using System.Collections.Generic;

namespace BookStore2.Models;

public partial class Autore
{
    public int IdAutor { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public bool? Ativo { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
