using MediatR;
using CleanArch.Application.UseCases;
using CleanArch.Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.QueryHandlers.Alunos;
using Azure.Core;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly ExcluirAlunoUseCase _excluirAlunoUseCase;
        private readonly IMediator _mediator;

        public AlunoController(IAlunoRepository repository,
            ExcluirAlunoUseCase excluirAlunoUseCase,
            IMediator mediator)
        {
            _repository = repository;
            _excluirAlunoUseCase = excluirAlunoUseCase;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlunos()
        {
            var query = new ListarTodosAlunosRequest();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUmAluno([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var query = new ListarUmAlunoRequest() { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAlunoAsync([FromBody] IncluirAlunoRequest request)
        {
            if (request == null)
            {
                _incluirAlunoUseCase.IncluirAluno(alunoDto.Nome, alunoDto.Endereco, alunoDto.Email);
                return Ok(alunoDto); 
            }

            var result = await _mediator.Send(request);

            if (result != null)
            {
                return Ok(result);
            }

        }

        [HttpPut]
        public async Task<IActionResult> AlterarAluno([FromBody] AlterarAlunoRequest request)
        {
            if (request == null)
            {
                _alterarAlunoUseCase.AlterarAluno(id, alunoAltDto.Nome, alunoAltDto.Endereco, alunoAltDto.Email, alunoAltDto.Ativo);
                return Ok(alunoAltDto); 
            }

            var result = await _mediator.Send(request);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Falha na alteração do aluno");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var query = new ExcluirAlunoRequest() { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
