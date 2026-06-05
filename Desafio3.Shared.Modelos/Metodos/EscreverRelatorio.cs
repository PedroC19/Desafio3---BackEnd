using Desafio3.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3___BackEnd.Metodos;

public class EscreverRelatorio
{
    public static void Relatorio(List<Produtos> lista)
    {

        var raizSolution = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));

        var pastaRelatorios = Path.Combine(raizSolution, "Relatorios");
        Directory.CreateDirectory(pastaRelatorios);

        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        var caminhoNovoArquivo = Path.Combine(pastaRelatorios, $"Relatorio_{timestamp}.txt");


        Console.WriteLine("Qual tipo de relatório gostaria?");
        Console.WriteLine("=======================");
        Console.WriteLine("1 - Geral");
        Console.WriteLine("2 - Filtrado Por Categoria");
        Console.WriteLine("=======================");


        Console.WriteLine($"Tentando criar em: {caminhoNovoArquivo}");
        switch (Console.ReadLine())
        {

            case "1":
                try
                {
                    using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
                    using (var produto = new StreamWriter(fluxoDoArquivo))
                    {

                        produto.WriteLine("===================================================================================");
                        foreach (var item in lista.DistinctBy(n => n.Nome))
                        {
                            int estoque = lista.Count(n => n.Nome == item.Nome);
                            produto.WriteLine($"Nome do Produto: {item.Nome}, Preço do produto: {item.Preco}, Quantidade em Estoque: {estoque}");
                            produto.WriteLine("-----------------------------------------------------------------------------------");

                        }
                        produto.WriteLine("===================================================================================");
                        var precoMax = lista.DistinctBy(p => p.Nome).MaxBy(p => p.Preco);
                        var precoMedio = lista.DistinctBy(p => p.Nome).Average(p => p.Preco);

                        produto.WriteLine($"Produto mais caro: {precoMax.Nome} com preço: {precoMax.Preco}");
                        produto.WriteLine($"Preço Médio: {precoMedio:F2}");
                        produto.WriteLine("===================================================================================");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                
                break;
            case "2":
                try
                {
                    Console.WriteLine("Qual categoria gostaria de filtrar?");
                    string categoria = Console.ReadLine();
                    var novaLista = lista.Where(p => p.Categoria == categoria).DistinctBy(p => p.Nome);
                    using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
                    using (var produto = new StreamWriter(fluxoDoArquivo))
                    {

                        produto.WriteLine("===================================================================================");
                        foreach (var item in novaLista)
                        {
                            int estoque = lista.Count(n => n.Nome == item.Nome);
                            produto.WriteLine($"Nome do Produto: {item.Nome}, Preço do produto: {item.Preco}, Quantidade em Estoque: {estoque}");
                            if (item != novaLista.Last())
                                produto.WriteLine("-----------------------------------------------------------------------------------");

                        }
                        produto.WriteLine("===================================================================================");
                        var precoMax = novaLista.Max(p => p.Preco);
                        var maisCaro = novaLista.Where(p => p.Preco == precoMax).ToList();
                        var precoMedio = novaLista.Average(p => p.Preco);

                        if (maisCaro.Count == 1)
                        {
                            produto.WriteLine($"Produto mais caro: {maisCaro[0].Nome} com preço: {maisCaro[0].Preco}");
                        }
                        else
                        {
                            produto.WriteLine($"Produtos mais caros (preço: {precoMax}):");
                            foreach (var caro in maisCaro)
                            {
                                produto.WriteLine($"  - {caro.Nome}");
                            }
                        }

                        produto.WriteLine($"Preço Médio: {precoMedio:F2}");
                        produto.WriteLine("===================================================================================");


                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                
                
                break;
        }

    }
    }

