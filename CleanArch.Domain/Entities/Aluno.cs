namespace CleanArch.Domain.Entities
{
    public class Aluno : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public static Aluno NovoAluno(string nome, string endereco, string email)
        {
            var aluno = new Aluno();
            aluno.Name = nome;
            aluno.Endereco = endereco;
            aluno.Email = email;
            aluno.Ativo = true;
            return aluno;
        }

        public Aluno AlterarNome(string novoNome)
        {
            Name = novoNome;
            return this;
        }
    }
}
