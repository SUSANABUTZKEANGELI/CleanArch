using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ListarTodosAlunosHandler : IRequestHandler<ListarTodosAlunosRequest, List<Aluno>>
    {
        private readonly IAlunoRepository _alunoRepository;

        public ListarTodosAlunosHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<List<Aluno>> Handle(ListarTodosAlunosRequest request, CancellationToken cancellationToken)
        {
            return _alunoRepository.SelecionarTudo2();
        }
    }
}
