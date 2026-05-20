using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Desafio3___BackEnd
{
    public class Produtos
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public string Categoria { get; set; }

        public string Extra { get; set; }

        public int _estoque;
        public int Estoque { get; set; }


        public Produtos(string nome, double preco, string categoria, string extra)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            Extra = extra;
        }

        public void AumentaEstoque()
        {
           Estoque++;
        }

       
        
    }
}
