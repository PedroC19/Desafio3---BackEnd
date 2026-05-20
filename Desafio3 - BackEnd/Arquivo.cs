using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Desafio3___BackEnd
{
    public class Arquivo
    {
        public static List<Produtos> abrirArquivo(string arquivo)
        {
            List<Produtos> prod = new List<Produtos>();
            var linhas = 1;
            using (var fs = new FileStream(arquivo, FileMode.Open))
            {

                var produtos = new StreamReader(fs);
                produtos.ReadLine();

                while (!produtos.EndOfStream)
                {
                   
                    try
                    {
                        linhas++;
                        var linha = produtos.ReadLine();
                        var campos = linha.Split(",");
                        var nome = campos[0];
                        if (string.IsNullOrEmpty(nome)) throw new NomeInvalidoException();
                        var preco = campos[1].Replace(".", ",");
                        if (string.IsNullOrEmpty(preco)) throw new PrecoVazioException();
                        var categoria = campos[2];
                        if (string.IsNullOrEmpty(categoria)) throw new CategoriaVaziaException();
                        var extra = campos[3];
                        if (campos.Length > 4) throw new CampoAMais();
                        var precoD = double.Parse(preco);
                        
                        if (precoD < 0) throw new PrecoNegativoException();
                        
                        prod.Add(new Produtos(nome, precoD, categoria, extra));
                    }
                    catch (NomeInvalidoException)
                    {
                        //Console.WriteLine($"Nome Vazio na linha {linhas}");
                    }
                    catch (Exception ex) when (ex is PrecoVazioException || ex is PrecoNegativoException || ex is FormatException)
                    { 
                        //Console.WriteLine($"Preco Inválido na linha {linhas}");
                    }
                    catch (Exception ex) when (ex is CategoriaVaziaException || ex is FormatException)
                    {
                        //Console.WriteLine($"Categoria vazia na linha {linhas}");
                    }
                    catch(Exception ex) when (ex is CampoAMais)
                    {
                        //Console.WriteLine($"Campo a mais na linha: {linhas}");
                    }
                }
            }
            return prod;

        }

        // Inserção de dados no file;
        public static void InserirDados(string arquivo)
        {
            string novoConteudo = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(arquivo, append: true))
            {
                sw.WriteLine(novoConteudo);
                
            }
        }

        /// <summary>
        /// Faz alteração de dados no arquivo, de forma basica;
        /// Utiliza switch para a escolha do parametro que vai ser alterado;
        /// Após fechar o switch, fazemos a reescrita do documento, alterando os dados selecionados para aquele produto especifico;
        /// Apenas busca pelo nome do Produto, então para selecionar ele somente utilziando o seu nome (pode ser alterado para buscar por outros produtos como valor ou categoria)
        /// </summary>
        /// <param name="arquivo">recebe o caminho do arquivo</param>
        /// <param name="lista">recebe a lista criada de produtos</param>

        internal static void alterarDados(string arquivo, List<Produtos> lista)
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
                            if(double.Parse(novoPreco) < 0)
                            {
                                Console.WriteLine("Preço não pode ser negativo");
                                break;
                            }

                            var aux = 0.0;
                            aux = item.Preco;
                            item.Preco = double.Parse(novoPreco);
                        }
                    }
                    break;
                case "Categoria":
                    string novaCat = Console.ReadLine();
                    foreach(var item in lista)
                    {
                        if(palavra == item.Nome)
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

        internal static void Imprimir(List<Produtos> lista)
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
                        if (item.Preco == double.Parse(preco))
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

        internal static void RemoverDados(string arquivo)
        {
            string palavra = "";
            List<string> linhas = new List<string>(File.ReadAllLines(arquivo));
            Console.WriteLine("Qual Produto gostaria de remover?" );
            palavra = Console.ReadLine();

            int removidas = linhas.RemoveAll(linha => linha.Contains(palavra));

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

        internal static void Relatorio(List<Produtos> lista)
        {
            
            var caminhoNovoArquivo = "C:/Users/pedro.colla/Desktop/Desafio 3/Relatorio.Txt";

            
            Console.WriteLine("Qual tipo de relatório gostaria?");
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Geral");
            Console.WriteLine("2 - Filtrado Por Categoria");
            Console.WriteLine("=======================");

            switch (Console.ReadLine())
            {
                
                case "1":

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
                    break;
                case "2":
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

                        if(maisCaro.Count == 1)
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
                    break;
            }

            


        }
    }
}

      

