using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio3.Shared.Modelos.Metodos;

internal class DivisorLinhasArquivo
{
    public static Produtos divisorLinhas(string produtos)
    {
        var linhas = 1;
        var nome = "";
        var preco = "";
        var categoria = "";
        var extra = "";
        decimal precoD = 0;
        try
        {
            linhas++;
            var linha = produtos;
            var campos = linha.Split(",");
            nome = campos[0].Trim();
            if (string.IsNullOrEmpty(nome)) throw new NomeInvalidoException();
            preco = campos[1].Replace(".", ",").Trim();
            if (string.IsNullOrEmpty(preco)) throw new PrecoVazioException();
            categoria = campos[2].Trim();
            if (string.IsNullOrEmpty(categoria)) throw new CategoriaVaziaException();
            extra = campos[3].Trim();
            if (campos.Length > 4) throw new CampoAMais();
            precoD = decimal.Parse(preco);

            if (precoD < 0) throw new PrecoNegativoException();

        }
        catch (NomeInvalidoException)
        {
            Console.WriteLine($"Nome Vazio na linha {linhas}");
        }
        catch (Exception ex) when (ex is PrecoVazioException || ex is PrecoNegativoException || ex is FormatException)
        {
            Console.WriteLine($"Preco Inválido na linha {linhas}");
        }
        catch (Exception ex) when (ex is CategoriaVaziaException || ex is FormatException)
        {
            Console.WriteLine($"Categoria vazia na linha {linhas}");
        }
        catch (Exception ex) when (ex is CampoAMais)
        {
            Console.WriteLine($"Campo a mais na linha: {linhas}");
        }
        return new Produtos(nome, precoD, categoria, extra);
    }
}


