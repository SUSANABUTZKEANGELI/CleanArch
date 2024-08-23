using CleanArch.API.Dtos;
using CleanArch.Data.UseCases;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
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
        public IActionResult IncluirProfessor([FromBody] ProfessorDto ProfessorDto)
        {
            if (ProfessorDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var professor = _incluirProfessorUseCase.IncluirProfessor(ProfessorDto.Nome, ProfessorDto.Email);

            if (professor != null)
            {
                return Ok(professor);
            }
            else
            {
                return BadRequest("Falha na inclusão do Professor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarProfessor(int id, [FromBody] ProfessorDto ProfessorDto)
        {
            if (id == null || ProfessorDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var Professor = _alterarProfessorUseCase.AlterarProfessor(id, ProfessorDto.Nome, ProfessorDto.Email);

            if (Professor != null)
            {
                return Ok(Professor);
            }
            else
            {
                return BadRequest("Falha na alteração do Professor");
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _excluirProfessorUseCase.ExcluirProfessor(id);

        }
    }
}
