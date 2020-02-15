using System;
using System.Collections.Generic;

namespace Cadastro.Entidades
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Cpf { get; set; }
        public ICollection<Nota> Notas { get; set; }


        public string Curso { get; set; }
    }
}
