using CleanArch.Domain.Entities.Enums;

namespace CleanArch.Domain.Entities
{
    public class Matricula : IEntity
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int IdCurso { get; set; }
        public Curso Curso { get; set; }
        public StatusMatricula StatusMatricula { get; set; }

        public static Matricula NovaMatricula(int idAluno, int idCurso)
        {

            var matricula = new Matricula();
            matricula.IdAluno = idAluno;
            matricula.IdCurso = idCurso;
            matricula.StatusMatricula = StatusMatricula.Ativa;

            return matricula;
        }

        public Matricula AlterarStatusMatricula(StatusMatricula novoStatusMatricula)
        {
            StatusMatricula = novoStatusMatricula;
            return this;
        }
    }
}
