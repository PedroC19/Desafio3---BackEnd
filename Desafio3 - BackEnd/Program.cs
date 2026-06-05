using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Desafio3.Shared.Dados;
using Desafio3.Shared.Modelos;
using Desafio3___BackEnd.Metodos;

namespace Desafio3___BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var arquivo = "C:\\Users\\pedro.colla\\Desktop\\Git\\Desafio3---BackEnd\\produtos.txt";

            List<Produtos> lista = new List<Produtos>();
            lista = Arquivo.abrirArquivo(arquivo);

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Pesquisar Produtos");
                Console.WriteLine("2. Adicionar produto");
                Console.WriteLine("3. Atualizar produto");
                Console.WriteLine("4. Remover produto");
                Console.WriteLine("5. Gerar relatório");
                Console.WriteLine("0. Sair");
                Console.WriteLine("================");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1": Imprimir.ImprimirDados(lista); break;
                    case "2": lista = Insercao.InserirDados(arquivo, lista); break;
                    case "3": Alterar.alterarDados(arquivo, lista); break;
                    case "4": Remocao.RemoverDados(arquivo, lista); break;
                    case "5": EscreverRelatorio.Relatorio(lista); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }
    }


    
        }