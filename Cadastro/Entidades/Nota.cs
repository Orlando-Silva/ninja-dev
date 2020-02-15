namespace Cadastro.Entidades
{
    public class Nota
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual int MateriaId { get; set; }
        public virtual int AlunoId { get; set; }
        public decimal Valor { get; set; }
    }
}
