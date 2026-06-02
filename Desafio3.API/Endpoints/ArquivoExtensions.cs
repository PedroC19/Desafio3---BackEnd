using Desafio3.API.Requests;
using Desafio3.API.Response;
using Desafio3.Shared.Dados;
using Desafio3.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using System.Runtime.CompilerServices;

namespace Desafio3.API.Endpoints;

// Oque precisa:
    // verificar lista de produtos : feito
    // verificar produto especifico : feito
    // adicionar novo produtos : feito
    // atualizar produto : feito
    // deletar produto : feito
        // todos atuam no bd;
    // Gerar Relatório

public static class ArquivoExtensions
{
    public static void AddEndPointsProdutos(this WebApplication app)
    {
        // Lista todos os Items do Banco de Dados
        app.MapGet("/Lista", ([FromServices] DAL<Produtos> dal) => 
        {
            var listadeProdutos = dal.Listar();
            if (listadeProdutos is null)
            {
                return Results.NotFound();
            }
            var listaDeArtistaResponse = EntityListToResponseList(listadeProdutos);
            return Results.Ok(listaDeArtistaResponse);
        });

        // Lista todos os Items que possuem a palavra no Nome;
        app.MapGet("/Lista1/{nome}", ([FromServices] DAL<Produtos> dal, string nome) =>
        {
            var produtos = dal.Listar()
                 .Where(p => p.Nome.Contains(nome)) // Contains recupera strings que tem a palavra, não precisando ser a string inteira (exemplo jaqueta --> Jaqueta de Couro)
                 .ToList();

            return Results.Ok(EntityListToResponseList(produtos));

        });

        // Lista todos os Items que possuem mesmo valor;
        app.MapGet("/Lista2/{preco}", ([FromServices] DAL<Produtos> dal, decimal preco) =>
        {
            var produtos = dal.Listar()
                  .Where(p => p.Preco.Equals(preco)) // Equals recupera apenas a igualdade, tendo que ser 1:1
                  .ToList();

            return Results.Ok(EntityListToResponseList(produtos));

        });

        // Lista todos os Items que possuem mesma categoria
        app.MapGet("/Lista3/{categoria}", ([FromServices] DAL<Produtos> dal, string categoria) =>
        {
            var produtos = dal.Listar()
                 .Where(p => p.Categoria.Contains(categoria)) // Contains recupera strings que tem a palavra, não precisando ser a string inteira (exemplo jaqueta --> Jaqueta de Couro)
                 .ToList();

            return Results.Ok(EntityListToResponseList(produtos));
        });
        // Lista quantidade de items no bd
        app.MapGet("/ListaContagem", ([FromServices] Desafio3Context context) =>
        {
            var quantidade = context.Produtos.Count();

            return Results.Ok(new
            {
                Quantidade = quantidade
            });
        });
        // Adiciona um novo item no bd
        app.MapPost("/Lista", ([FromServices] DAL<Produtos> dal, [FromBody] ProdutosRequest produtosRequest) =>
        {
            var artista = new Produtos(produtosRequest.nome, produtosRequest.preco, produtosRequest.categoria, produtosRequest.extra);

            dal.Adicionar(artista);
            return Results.Ok();
        });

        // deleta um item do BD
        app.MapDelete("/Lista/{id}", ([FromServices] DAL<Produtos> dal, string nome) => {
            var artista = dal.RecuperarPor(a => a.Nome == nome);
            if (artista is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(artista);
            return Results.NoContent();
        });
        // Atualiza o Item da Lista
        app.MapPut("/Artistas", ([FromServices] DAL<Produtos> dal, [FromBody] ProdutosRequestEdit produtosRequestEdit) => {
            var produtoAtualizar = dal.RecuperarPor(a => a.Id == produtosRequestEdit.Id);
            if (produtoAtualizar is null)
            {
                return Results.NotFound();
            }
            produtoAtualizar.Nome = produtosRequestEdit.nome;
            produtoAtualizar.Preco = produtosRequestEdit.preco;
            produtoAtualizar.Categoria = produtosRequestEdit.categoria;
            produtoAtualizar.Extra = produtosRequestEdit.extra;
            dal.Atualizar(produtoAtualizar);
            return Results.Ok();
        });

        // Tem que descobrir como fazer o relatorio:
    }

    private static ICollection<ProdutoResponse> EntityListToResponseList(IEnumerable<Produtos> listadeProdtuos)
    {
        return listadeProdtuos.Select(a => EntityToResponse(a)).ToList();
    }

    private static ProdutoResponse EntityToResponse(Produtos produtos)
    {
        return new ProdutoResponse(produtos.Nome, produtos.Preco, produtos.Categoria, produtos.Extra);
    }

}