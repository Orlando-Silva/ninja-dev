using Cadastro.Entidades;
using Cadastro.Repositório;
using System.Collections.Generic;

namespace Cadastro.Serviços
{
    public class MateriaService
    {
        private readonly IRepositorioBase<Materia> _repositorio;

        public MateriaService(IRepositorioBase<Materia> repositorio)
        {
            _repositorio = repositorio;
        }

        public Materia Cadastrar(Materia materia)
        {
            return _repositorio.Salvar(materia);
        }

        public Materia BuscarPorId(int id)
        {
            return _repositorio.Buscar(id);
        }

        public Materia BuscarPorDescricao(string descricao)
        {
            return _repositorio.Buscar(m => m.Descricao.Equals(descricao, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public List<Materia> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Materia AlterarStatus(Materia materia)
        {
            materia.Situacao = materia.Situacao == Situacao.Ativo
                ? Situacao.Inativo
                : Situacao.Ativo;

            _repositorio.Atualizar(materia.Id, materia);
            return materia;
        }

        public List<Materia> BuscarTodos(Situacao situacao)
        {
            return _repositorio.BuscarTodos(m => m.Situacao == situacao);
        }

        public void Excluir(Materia materia)
        {
            _repositorio.Deletar(materia);
        }
    }
}
