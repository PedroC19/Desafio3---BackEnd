using Desafio3.Shared.Modelos;
using Desafio3.Shared.Modelos.Metodos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3___BackEnd.Metodos;

public class Insercao
{
    public static List<Produtos> InserirDados(string arquivo, List<Produtos> lista)
    {
        string novoConteudo = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(arquivo, append: true))
        {
            sw.WriteLine(novoConteudo);
            lista.Add(DivisorLinhasArquivo.divisorLinhas(novoConteudo));
        }
        return lista;
    }
}

