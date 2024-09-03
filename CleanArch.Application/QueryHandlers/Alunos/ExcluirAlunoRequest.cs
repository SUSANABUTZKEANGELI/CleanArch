using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class ExcluirAlunoRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
