using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ListarTodosAlunosRequest : IRequest<List<Aluno>>
    {
    }
}
