using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cadastro.Repositório
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public Contexto Contexto { get; set; }

        public RepositorioBase(Contexto contexto)
        {
            Contexto = contexto;
        }

        public T Buscar(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public T Buscar(Expression<Func<T, bool>> predicato)
        {
            return Contexto.Set<T>().FirstOrDefault(predicato);
        }

        public List<T> BuscarTodos()
        {
            return Contexto.Set<T>().ToList(); 
        }

        public List<T> BuscarTodos(Expression<Func<T, bool>> predicato)
        {
            return Contexto.Set<T>().Where(predicato).ToList();
        }

        public T Deletar(T entidade)
        {
            Contexto.Set<T>().Remove(entidade);
            Contexto.SaveChanges();
            return entidade;
        }

        public T Salvar(T entidade)
        {
            entidade = Contexto.Set<T>().Add(entidade);
            Contexto.SaveChanges();
            return entidade;
        }

        public T Atualizar(int id, T entidade)
        {
            var entidadeExistente = Contexto.Set<T>().Find(id);
            entidadeExistente = entidade;
            Contexto.SaveChanges();
            return entidade;
        }
    }
}
