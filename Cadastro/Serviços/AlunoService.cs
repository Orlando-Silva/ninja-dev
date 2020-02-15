using Cadastro.Entidades;
using Cadastro.Repositório;
using System.Collections.Generic;

namespace Cadastro.Serviços
{
    public class AlunoService
    {
        private readonly IRepositorioBase<Aluno> _repositorio;

        public AlunoService(IRepositorioBase<Aluno> repositorio)
        {
            _repositorio = repositorio;
        }

        public Aluno Cadastrar(Aluno aluno)
        {
            return _repositorio.Salvar(aluno);
        }

        public Aluno BuscarPorId(int id)
        {
            return _repositorio.Buscar(id);
        }

        public Aluno BuscarPorNomeSobrenome(string nome, string sobrenome)
        {  
            return _repositorio.Buscar(a => a.Nome.Equals(nome, System.StringComparison.InvariantCultureIgnoreCase) && a.Sobrenome.Equals(sobrenome, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public Aluno BuscarPorCpf(string cpf)
        {
            return _repositorio.Buscar(a => a.Cpf == cpf);
        }

        public Aluno Excluir(Aluno aluno)
        {
            return _repositorio.Deletar(aluno);
        }

        public List<Aluno> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }
    }
}
