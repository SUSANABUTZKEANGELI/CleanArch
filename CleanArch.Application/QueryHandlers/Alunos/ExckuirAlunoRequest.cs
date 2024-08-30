using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ExcluirAlunoRequest : IRequest<Aluno>
    {
        public int Id { get; set; }
    }
}
