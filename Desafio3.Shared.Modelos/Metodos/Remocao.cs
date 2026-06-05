using Desafio3.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3___BackEnd.Metodos;

public class Remocao
{
    public static void RemoverDados(string arquivo, List<Produtos> lista)
    {
        string palavra = "";
        List<string> linhas = new List<string>(File.ReadAllLines(arquivo));
        Console.WriteLine("Qual Produto gostaria de remover?");
        palavra = Console.ReadLine();

        int removidas = linhas.RemoveAll(linha => linha.Contains(palavra));
        lista.RemoveAll(p => p.Nome.Contains(palavra));

        if (removidas > 0)
        {
            // Sobrescreve o arquivo com as linhas    
            File.WriteAllLines(arquivo, linhas);
            Console.WriteLine($"{removidas} linha(s) removida(s) com sucesso.");
        }
        else
        {
            Console.WriteLine("Nenhuma linha encontrada com o dado informado.");
        }
    }
}
