using Desafio3.API.Requests;

namespace ScreenSound.API.Requests;

public record ProdutosRequestEdit(int Id, string nome, decimal preco, string categoria, string extra)
    : ProdutosRequest(nome, preco, categoria, extra);