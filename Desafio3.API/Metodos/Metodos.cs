using Desafio3.API.Requests;
using Desafio3.API.Response;
using Desafio3.Shared.Dados;
using Desafio3.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using System.Text;

namespace Desafio3.API.Metodos;

public static class  MetodoGet
{
    #region "Gets"
    public static IResult EndPointGetLista([FromServices] DAL<Produtos> dal)
    {
        var listadeProdutos = dal.Listar();
        if (listadeProdutos is null)
        {
            return Results.NotFound();
        }
        var listaDeArtistaResponse = EntityListToResponseList(listadeProdutos);
        return Results.Ok(listaDeArtistaResponse);
    }

    public static IResult EndPointGetListaNome([FromServices] DAL<Produtos> dal, string nome)
    {
        var produtos = dal.Listar(p => p.Nome.Contains(nome));
        return Results.Ok(EntityListToResponseList(produtos));
    }

    public static IResult EndPointGetListaPreco([FromServices] DAL<Produtos> dal, decimal preco)
    {
        var produtos = dal.Listar(p => p.Preco.Equals(preco));
                 
        return Results.Ok(EntityListToResponseList(produtos));
    }

    public static IResult EndPointGetListaCategoria([FromServices] DAL<Produtos> dal, string categoria)
    {
        var produtos = dal.Listar(p => p.Categoria.Contains(categoria));
        return Results.Ok(EntityListToResponseList(produtos));
    }

    public static IResult EndPointGetListaContagem([FromServices] Desafio3Context context)
    {
        var quantidade = context.Produtos.Count();

        return Results.Ok(new
        {
            Quantidade = quantidade
        });
    }

    public static IResult EndPointGetRelatorio([FromServices] DAL<Produtos> dal, string? categoria)
    {
        var lista = dal.Listar();

            if (!string.IsNullOrEmpty(categoria))
            {
                lista = lista.Where(p => p.Categoria == categoria);
            }

            var sb = new StringBuilder();

            sb.AppendLine("========================================");

            foreach (var item in lista.DistinctBy(p => p.Nome))
            {
                int estoque = lista.Count(p => p.Nome == item.Nome);

                sb.AppendLine(
                    $"Nome: {item.Nome} | Preço: {item.Preco:C} | Estoque: {estoque}"
                );
            }

            sb.AppendLine("========================================");

            var produtosDistintos = lista.DistinctBy(p => p.Nome);

            if (produtosDistintos.Any())
            {
                var maisCaro = produtosDistintos.MaxBy(p => p.Preco);
                var precoMedio = produtosDistintos.Average(p => p.Preco);

                sb.AppendLine(
                    $"Produto mais caro: {maisCaro!.Nome} - {maisCaro.Preco:C}"
                );

                sb.AppendLine(
                    $"Preço médio: {precoMedio:C}"
                );
            }

            return Results.Text(sb.ToString(), "text/plain");
    }
    #endregion

    #region "Post's"
    public static class MetodoPost
    {
        public static IResult EndPointPostAdiciona([FromServices] DAL<Produtos> dal, [FromBody] ProdutosRequest produtosRequest)
        {

            if (string.IsNullOrWhiteSpace(produtosRequest.nome))
                return Results.BadRequest("Nome não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(produtosRequest.categoria))
                return Results.BadRequest("Categoria não pode ser vazia.");

            if (produtosRequest.preco <= 0)
                return Results.BadRequest("Preço deve ser maior que zero.");

            var produto = new Produtos(produtosRequest.nome, produtosRequest.preco, produtosRequest.categoria, produtosRequest.extra);

            dal.Adicionar(produto);
            return Results.Ok();
        }
    }
    #endregion

    #region "Put's"
    public static class MetodoPut
    {
        public static IResult EndPointPutAtualiza([FromServices] DAL<Produtos> dal, [FromBody] ProdutosRequestEdit produtosRequestEdit)
        {
            if (string.IsNullOrWhiteSpace(produtosRequestEdit.nome))
                return Results.BadRequest("Nome não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(produtosRequestEdit.categoria))
                return Results.BadRequest("Categoria não pode ser vazia.");

            if (produtosRequestEdit.preco <= 0)
                return Results.BadRequest("Preço deve ser maior que zero.");

            var produtoAtualizar = dal.RecuperarPor(a => a.Id == produtosRequestEdit.Id);
            if (produtoAtualizar is null)
                return Results.NotFound();



            produtoAtualizar.Nome = produtosRequestEdit.nome;
            produtoAtualizar.Preco = produtosRequestEdit.preco;
            produtoAtualizar.Categoria = produtosRequestEdit.categoria;
            produtoAtualizar.Extra = produtosRequestEdit.extra;
            dal.Atualizar(produtoAtualizar);
            return Results.Ok();
        }
    }

    #endregion

    #region "Delete's"
    public static class MetodoDelete
        {
            public static IResult EndPointDeleteRemove([FromServices] DAL<Produtos> dal, string nome)
            {
                var artista = dal.RecuperarPor(a => a.Nome == nome);
                if (artista is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(artista);
                return Results.NoContent();
            }
        }

    #endregion

    private static ICollection<ProdutoResponse> EntityListToResponseList(IEnumerable<Produtos> listadeProdtuos)
    {
        return listadeProdtuos.Select(a => EntityToResponse(a)).ToList();
    }

    private static ProdutoResponse EntityToResponse(Produtos produtos)
    {
        return new ProdutoResponse(produtos.Nome, produtos.Preco, produtos.Categoria, produtos.Extra);
    }






}
