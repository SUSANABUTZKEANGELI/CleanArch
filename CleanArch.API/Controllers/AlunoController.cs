using CleanArch.API.Dtos;
using CleanArch.Application.UseCases;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly IncluirAlunoUseCase _incluirAlunoUseCase;
        private readonly ListarTodosAlunosUseCase _listarTodosAlunosUseCase;
        private readonly ListarUmAlunoUseCase _listarUmAlunoUseCase;
        private readonly AlterarAlunoUseCase _alterarAlunoUseCase;
        private readonly ExcluirAlunoUseCase _excluirAlunoUseCase;

        public AlunoController(IAlunoRepository repository, 
            IncluirAlunoUseCase incluirAlunoUseCase,
            ListarTodosAlunosUseCase listarTodosAlunosUseCase,
            ListarUmAlunoUseCase listarUmAlunoUseCase,
            AlterarAlunoUseCase alterarAlunoUseCase,
            ExcluirAlunoUseCase excluirAlunoUseCase)
        {
            _repository = repository;
            _incluirAlunoUseCase = incluirAlunoUseCase;
            _listarTodosAlunosUseCase = listarTodosAlunosUseCase;
            _listarUmAlunoUseCase = listarUmAlunoUseCase;
            _alterarAlunoUseCase = alterarAlunoUseCase;
            _excluirAlunoUseCase = excluirAlunoUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            var alunos = _listarTodosAlunosUseCase.ListarAlunos();
            return alunos == null ? NotFound() : alunos;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var aluno = _listarUmAlunoUseCase.ListarUmAluno(id);
            return aluno == null ? NotFound() : Ok(aluno); 
        }

        [HttpPost]
        public IActionResult IncluirAluno([FromBody] AlunoDto alunoDto)
        {            
            try
            {
                _incluirAlunoUseCase.IncluirAluno(alunoDto.Nome, alunoDto.Endereco, alunoDto.Email);
                return Ok(alunoDto); 
            }
            catch (ValidationException ex)
            {
                // Cria uma resposta com os erros de validação
                var errors = ex.Errors.Select(e => new { e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }

        }

        [HttpPut("{id}")]
        public IActionResult AlterarAluno(int id, [FromBody] AlunoAltDto alunoAltDto)
        {            
            try
            {
                _alterarAlunoUseCase.AlterarAluno(id, alunoAltDto.Nome, alunoAltDto.Endereco, alunoAltDto.Email, alunoAltDto.Ativo);
                return Ok(alunoAltDto); 
            }
            catch (ValidationException ex)
            {
                if (ex.Message == "Aluno Inexistente")
                {
                    return NotFound(new { Message = ex.Message }); 
                }

                // Cria uma resposta com os erros de validação
                var errors = ex.Errors.Select(e => new { e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _excluirAlunoUseCase.ExcluirAluno(id);

        }
    }
}
