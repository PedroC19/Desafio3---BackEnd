using Desafio3.API.Metodos;
using Desafio3.API.Requests;
using Desafio3.API.Response;
using Desafio3.Shared.Dados;
using Desafio3.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using System.Runtime.CompilerServices;
using System.Text;
using static Desafio3.API.Metodos.MetodoGet;

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
        app.MapGet("/Lista", MetodoGet.EndPointGetLista);

        // Lista todos os Items que possuem a palavra no Nome;
        app.MapGet("/Lista1/{nome}", MetodoGet.EndPointGetListaNome);

        // Lista todos os Items que possuem mesmo valor;
        app.MapGet("/Lista2/{preco}", MetodoGet.EndPointGetListaPreco);

        // Lista todos os items que possuem mesma categoria;
        app.MapGet("/Lista3/{categoria}", MetodoGet.EndPointGetListaCategoria);

        // Lista quantidade de items no bd
        app.MapGet("/ListaContagem", MetodoGet.EndPointGetListaContagem);
        
        // Gera Relatorio com todos os dados
        app.MapGet("/Relatorio", MetodoGet.EndPointGetRelatorio);

        // Adiciona um novo item no bd
        app.MapPost("/Lista", MetodoPost.EndPointPostAdiciona);

        // Atualiza o Item da Lista
        app.MapPut("/Lista", MetodoPut.EndPointPutAtualiza);

        // deleta um item do BD
        app.MapDelete("/Lista/{id}", MetodoDelete.EndPointDeleteRemove);

    }

}