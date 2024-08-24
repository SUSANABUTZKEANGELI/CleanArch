
namespace CleanArch.Domain.Entities
{
    public class Curso : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
        public DateTime ApplicationInicio { get; set; }
        public bool Ativo { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public static Curso NovoCurso(string nome, string descricao, int idProfessor, DateTime ApplicationInicio)
        {
            var curso = new Curso();
            curso.Nome = nome;
            curso.Descricao = descricao;
            curso.IdProfessor = idProfessor;
            curso.ApplicationInicio = ApplicationInicio;
            curso.Professor = new Professor();
            curso.Matriculas = new List<Matricula>();

            return curso;
        }

        public Curso AlterarNome(string novoNome)
        {
            Nome = novoNome;
            return this;
        }
    }
}
