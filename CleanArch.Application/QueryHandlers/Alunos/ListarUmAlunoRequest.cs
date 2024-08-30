using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ListarUmAlunoRequest : IRequest<Aluno>
    {
        public int Id { get; set; }
    }
}
