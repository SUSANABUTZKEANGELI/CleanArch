using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ListarUmAlunoHandler : IRequestHandler<ListarUmAlunoRequest, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public ListarUmAlunoHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<Aluno> Handle(ListarUmAlunoRequest request, CancellationToken cancellationToken)
        {
            return _alunoRepository.SelecionarPorId2(request.Id);
        }
    }
}
