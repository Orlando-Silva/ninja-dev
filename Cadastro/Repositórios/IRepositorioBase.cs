using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cadastro.Repositório
{
    public interface IRepositorioBase<T> where T : class
    {
        Contexto Contexto { get; set; }
        T Salvar(T entidade);

        T Atualizar(int id, T entidade);

        T Buscar(int id);
        T Buscar(Expression<Func<T, bool>> predicato);

        List<T> BuscarTodos();
        List<T> BuscarTodos(Expression<Func<T, bool>> predicato);

        T Deletar(T entidade);
    }
}
