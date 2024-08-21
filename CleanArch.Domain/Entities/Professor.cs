
namespace CleanArch.Domain.Entities
{
    public class Professor : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Curso> Cursos { get; set; }

        public static Professor NovoProfessor(string nome, string email)
        {
            var prof = new Professor();
            prof.Nome = nome;
            prof.Email = email;

            return prof;
        }

        public Professor AlterarNome(string novoNome)
        {
            Nome = novoNome;
            return this;
        }
    }
}
