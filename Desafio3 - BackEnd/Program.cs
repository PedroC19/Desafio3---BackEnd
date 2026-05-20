using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Desafio3___BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {

            // abre o arquivo
            var arquivo = "C:\\Users\\pedro.colla\\Desktop\\Desafio\\Desafio3---BackEnd\\produtos.txt";

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
                    case "1": Arquivo.Imprimir(lista); break;
                    case "2": lista = Arquivo.InserirDados(arquivo, lista); break;
                    case "3": Arquivo.alterarDados(arquivo, lista); break;
                    case "4": Arquivo.RemoverDados(arquivo, lista); break;
                    case "5": Arquivo.Relatorio(lista); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }

            Console.ReadLine();
        }
    }


    
        }