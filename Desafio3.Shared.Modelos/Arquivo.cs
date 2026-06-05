using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Desafio3;
using Desafio3.Shared.Modelos.Metodos;
using Desafio3___BackEnd.Metodos;
namespace Desafio3.Shared.Modelos

{
    public  class Arquivo
    {      
        public static List<Produtos> abrirArquivo(string arquivo)
        {
            List<Produtos> prod = new List<Produtos>();
            using (var fs = new FileStream(arquivo, FileMode.Open))
            {
                var produtos = new StreamReader(fs);
                produtos.ReadLine();   
                while (!produtos.EndOfStream)
                {
                    string linha = produtos.ReadLine();
                    prod.Add(DivisorLinhasArquivo.divisorLinhas(linha));
                }
            }
            return prod;
        }
    }
}

      


