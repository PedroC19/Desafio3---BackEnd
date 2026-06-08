using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio3.Shared.Modelos;

namespace Desafio3.Shared.Dados;

public class DAL<T> where T : class
{
    private readonly Desafio3Context context;

    public DAL(Desafio3Context context)
    {
        this.context = context;
    }


    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }

    public IEnumerable<T> Listar(Func<T, bool> filtro)
    {
        return context.Set<T>().Where(filtro).ToList();
    }
    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }
    public void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
        
    }
}
