using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class AlterarAlunoRequest : IRequest<Aluno>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}
