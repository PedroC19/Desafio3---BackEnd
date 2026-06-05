using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Desafio3.Shared.Modelos
{
    public class Produtos
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public decimal? Preco { get; set; }

        public string? Categoria { get; set; }

        public string? Extra { get; set; }

        public Produtos()
        {

        }
        public Produtos(string nome, decimal preco, string categoria, string extra)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            Extra = extra;
        }

    }
}
