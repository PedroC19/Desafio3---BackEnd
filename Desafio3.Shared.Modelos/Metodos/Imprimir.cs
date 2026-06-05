using Desafio3.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3___BackEnd.Metodos
{
    public class Imprimir
    {
        public static void ImprimirDados(List<Produtos> lista)
        {
            Console.WriteLine("Selecione uma Opção para realizar a pesquisa:");
            Console.WriteLine("== Lista ==");
            Console.WriteLine("== Nome ==");
            Console.WriteLine("== Preco ==");
            Console.WriteLine("== Categoria ==");
            switch (Console.ReadLine())
            {
                case "Lista":
                    foreach (var item in lista.DistinctBy(p => p.Nome))
                    {
                        Console.WriteLine("========================================");
                        Console.WriteLine($"Nome do Produto: {item.Nome}");
                        Console.WriteLine($"Preço do Produto: {item.Preco}");
                        Console.WriteLine($"Categoria do Produto: {item.Categoria}");
                        Console.WriteLine($"Extra do Produto: {item.Extra}");
                        Console.WriteLine("========================================");
                    }
                    break;
                case "Nome":
                    string word = Console.ReadLine();
                    foreach (var item in lista.DistinctBy(p => p.Nome))
                    {
                        if (word == item.Nome)
                        {
                            Console.WriteLine("========================================");
                            Console.WriteLine($"Nome do Produto: {item.Nome}");
                            Console.WriteLine($"Preço do Produto: {item.Preco}");
                            Console.WriteLine($"Categoria do Produto: {item.Categoria}");
                            Console.WriteLine($"Extra do Produto: {item.Extra}");
                            Console.WriteLine("========================================");
                        }
                    }
                    break;
                case "Preco":
                    string preco = Console.ReadLine();
                    foreach (var item in lista.DistinctBy(p => p.Nome))
                    {
                        if (item.Preco == decimal.Parse(preco))
                        {
                            Console.WriteLine("========================================");
                            Console.WriteLine($"Nome do Produto: {item.Nome}");
                            Console.WriteLine($"Preço do Produto: {item.Preco}");
                            Console.WriteLine($"Categoria do Produto: {item.Categoria}");
                            Console.WriteLine($"Extra do Produto: {item.Extra}");
                            Console.WriteLine("========================================");
                        }
                    }
                    break;
                case "Categoria":
                    string cat = Console.ReadLine();
                    foreach (var item in lista.DistinctBy(p => p.Nome))
                    {
                        if (cat == item.Categoria)
                        {
                            Console.WriteLine("========================================");
                            Console.WriteLine($"Nome do Produto: {item.Nome}");
                            Console.WriteLine($"Preço do Produto: {item.Preco}");
                            Console.WriteLine($"Categoria do Produto: {item.Categoria}");
                            Console.WriteLine($"Extra do Produto: {item.Extra}");
                            Console.WriteLine("========================================");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

        }
    }
}
