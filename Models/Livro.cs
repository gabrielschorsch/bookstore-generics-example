using System;
using System.Collections.Generic;

namespace BookStore2.Models;

public partial class Livro
{
    public int IdLivro { get; set; }

    public string Titulo { get; set; } = null!;

    public int? IdAutor { get; set; }

    public int? IdGenero { get; set; }

    public virtual Autore? IdAutorNavigation { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }
}
