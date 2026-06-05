using Desafio3.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3___BackEnd.Metodos;

public class Alterar
{
    public static void alterarDados(string arquivo, List<Produtos> lista)
    {
        Console.WriteLine("Qual produto gostaria de alterar?");
        string palavra = Console.ReadLine();
        Console.WriteLine($"Produto escolhido: {palavra}");
        Console.WriteLine("O que gostaria de alterar?");
        string opcao = Console.ReadLine();
        Console.WriteLine($"Opção escolhida foi: {opcao}");
        switch (opcao)
        {
            case "Nome":
                string novoNome = Console.ReadLine();
                foreach (var item in lista)
                {
                    if (palavra == item.Nome)
                    {
                        var aux = "";
                        aux = item.Nome;
                        item.Nome = novoNome;
                    }
                }
                break;
            case "Preço":
                string novoPreco = Console.ReadLine();
                foreach (var item in lista)
                {
                    if (palavra == item.Nome)
                    {
                        if (decimal.Parse(novoPreco) < 0)
                        {
                            Console.WriteLine("Preço não pode ser negativo");
                            break;
                        }

                        decimal? aux = 0;
                        aux = item.Preco;
                        item.Preco = decimal.Parse(novoPreco);
                    }
                }
                break;
            case "Categoria":
                string novaCat = Console.ReadLine();
                foreach (var item in lista)
                {
                    if (palavra == item.Nome)
                    {
                        var aux = "";
                        aux = item.Categoria;
                        item.Categoria = novaCat;
                    }
                }
                break;
            case "Extra":
                string novoExtra = Console.ReadLine();
                foreach (var item in lista)
                {
                    if (palavra == item.Nome)
                    {
                        var aux = "";
                        aux = item.Extra;
                        item.Extra = novoExtra;
                    }
                }
                break;
            default:
                Console.WriteLine("Não existe essa opção!"); break;
        }
        using (StreamWriter sw = new StreamWriter(arquivo, append: false))
        {
            sw.WriteLine("Nome,Preco,Categoria,Extra");
            foreach (var item in lista)
            {
                string precoFormatado = item.Preco.ToString().Replace(",", ".");
                sw.WriteLine($"{item.Nome},{precoFormatado},{item.Categoria},{item.Extra}");
            }
        }
    }

}
