using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class IncluirAlunoRequest : IRequest<Aluno>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }
}
