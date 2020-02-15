using System;
using System.Collections.Generic;

namespace Cadastro.Entidades
{
    public class Materia
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public ICollection<Nota> Notas { get; set; }

        public Situacao Situacao { get; set; }
    }
}
