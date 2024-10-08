﻿using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ExcluirAlunoHandler : IRequestHandler<ExcluirAlunoRequest, Unit>
    {
        private readonly IAlunoRepository _alunoRepository;

        public ExcluirAlunoHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Unit> Handle(ExcluirAlunoRequest request, CancellationToken cancellationToken)
        {
            var aluno = _alunoRepository.SelecionarPorId2(request.Id);

            if (aluno != null)
            {
                await _alunoRepository.Excluir2(request.Id);
            }

            return Unit.Value;
        }
                
    }
}
