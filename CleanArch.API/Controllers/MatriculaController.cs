using CleanArch.API.Dtos;
using CleanArch.Application.UseCases;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _repository;
        private readonly IncluirMatriculaUseCase _incluirMatriculaUseCase;
        private readonly ListarTodasMatriculasUseCase _listarTodasMatriculasUseCase;
        private readonly AlterarMatriculaUseCase _alterarMatriculaUseCase;

        public MatriculaController(IMatriculaRepository repository, 
            IncluirMatriculaUseCase incluirMatriculaUseCase,
            ListarTodasMatriculasUseCase listarTodasMatriculasUseCase,
            AlterarMatriculaUseCase alterarMatriculaUseCase)
        {
            _repository = repository;
            _incluirMatriculaUseCase = incluirMatriculaUseCase;
            _listarTodasMatriculasUseCase = listarTodasMatriculasUseCase;
            _alterarMatriculaUseCase = alterarMatriculaUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Matricula>> Get()
        {
            var matriculas = _listarTodasMatriculasUseCase.ListarMatriculas();
            return matriculas == null ? NotFound() : matriculas;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var matricula = _repository.SelecionarPorId(id);
            return matricula == null ? NotFound() : Ok(matricula); 
        }

        [HttpPost]
        public IActionResult Matricular([FromBody] MatriculaDto matriculaDto)
        {
            if (matriculaDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var matricula = _incluirMatriculaUseCase.Matricular(matriculaDto.IdCurso, matriculaDto.IdAluno);

            if (matricula != null)
            {
                return Ok(matricula);
            }
            else
            {
                return BadRequest("Falha na inclusão da matrícula");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MatriculaAltDto matriculaAltDto)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var matricula = _alterarMatriculaUseCase.AlterarMatricula(id, matriculaAltDto.StatusMatricula);

            if (matricula != null)
            {
                return Ok(matricula);
            }
            else
            {
                return BadRequest("Falha na alteração da matricula");
            }
        }
    }
}
