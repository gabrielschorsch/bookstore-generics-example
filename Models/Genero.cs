using System;
using System.Collections.Generic;

namespace BookStore2.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
