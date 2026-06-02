using System.ComponentModel.DataAnnotations;

namespace Desafio3.API.Requests;

public record ProdutosRequest([Required] string nome, [Required] decimal preco, [Required] string categoria, string extra);