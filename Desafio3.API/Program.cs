using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Desafio3.API.Endpoints;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using Desafio3.Shared.Dados;
using Desafio3.Shared.Modelos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Desafio3Context>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:Desafio3"]).UseLazyLoadingProxies();
});
builder.Services.AddTransient<DAL<Produtos>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsProdutos();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
