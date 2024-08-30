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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repository;
        private readonly IncluirProfessorUseCase _incluirProfessorUseCase;
        private readonly ListarTodosProfessoresUseCase _listarTodosProfessoresUseCase;
        private readonly ListarUmProfessorUseCase _listarUmProfessorUseCase;
        private readonly AlterarProfessorUseCase _alterarProfessorUseCase;
        private readonly ExcluirProfessorUseCase _excluirProfessorUseCase;

        public ProfessorController(IProfessorRepository repository, 
            IncluirProfessorUseCase incluirProfessorUseCase,
            ListarTodosProfessoresUseCase listarTodosProfessoresUseCase,
            ListarUmProfessorUseCase listarUmProfessorUseCase,
            AlterarProfessorUseCase alterarProfessorUseCase,
            ExcluirProfessorUseCase excluirProfessorUseCase)
        {
            _repository = repository;
            _incluirProfessorUseCase = incluirProfessorUseCase;
            _listarTodosProfessoresUseCase = listarTodosProfessoresUseCase;
            _listarUmProfessorUseCase = listarUmProfessorUseCase;
            _alterarProfessorUseCase = alterarProfessorUseCase;
            _excluirProfessorUseCase = excluirProfessorUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            var professores = _listarTodosProfessoresUseCase.ListarProfessores();
            return professores == null ? NotFound() : professores;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var professor = _listarUmProfessorUseCase.ListarUmProfessor(id);
            return professor == null ? NotFound() : Ok(professor); 
        }

        [HttpPost]
        public IActionResult IncluirProfessor([FromBody] ProfessorDto professorDto)
        {            
            try
            {
                _incluirProfessorUseCase.IncluirProfessor(professorDto.Nome, professorDto.Email);
                return Ok(professorDto); 
            }
            catch (ValidationException ex)
            {
                // Cria uma resposta com os erros de validação
                var errors = ex.Errors.Select(e => new { e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarProfessor(int id, [FromBody] ProfessorDto professorDto)
        {            
            try
            {
                _alterarProfessorUseCase.AlterarProfessor(id, professorDto.Nome, professorDto.Email);
                return Ok(professorDto);
            }
            catch (ValidationException ex)
            {
                if (ex.Message == "Professor Inexistente")
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
            _excluirProfessorUseCase.ExcluirProfessor(id);

        }
    }
}
