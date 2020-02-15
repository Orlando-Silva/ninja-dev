using Cadastro.Entidades;
using Cadastro.Repositório;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Serviços
{
    public class NotaService
    {
        private readonly IRepositorioBase<Nota> _repositorio;

        public NotaService(IRepositorioBase<Nota> repositorio)
        {
            _repositorio = repositorio;
        }

        public Nota Cadastrar(Nota nota)
        {
            return _repositorio.Salvar(nota);
        }

        public Nota BuscarPorId(int id)
        {
            return _repositorio.Buscar(id);
        }

        public List<Nota> BuscarPorAluno(int id)
        {
            return _repositorio.Contexto.Notas.Where(m => m.AlunoId == id).ToList();
        } 

        public List<Nota> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

    }
}
