using CleanArch.API.Dtos;
using CleanArch.Data.UseCases;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _repository;
        private readonly IncluirCursoUseCase _incluirCursoUseCase;
        private readonly ListarTodosCursosUseCase _listarTodosCursosUseCase;
        private readonly ListarUmCursoUseCase _listarUmCursoUseCase;
        private readonly AlterarCursoUseCase _alterarCursoUseCase;
        private readonly ExcluirCursoUseCase _excluirCursoUseCase;

        public CursoController(ICursoRepository repository, 
            IncluirCursoUseCase incluirCursoUseCase,
            ListarTodosCursosUseCase listarTodosCursosUseCase,
            ListarUmCursoUseCase listarUmCursoUseCase,
            AlterarCursoUseCase alterarCursoUseCase,
            ExcluirCursoUseCase excluirCursoUseCase)
        {
            _repository = repository;
            _incluirCursoUseCase = incluirCursoUseCase;
            _listarTodosCursosUseCase = listarTodosCursosUseCase;
            _listarUmCursoUseCase = listarUmCursoUseCase;
            _alterarCursoUseCase = alterarCursoUseCase;
            _excluirCursoUseCase = excluirCursoUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var cursos = _listarTodosCursosUseCase.ListarCursos();
            return cursos == null ? NotFound() : cursos;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var curso = _listarUmCursoUseCase.ListarUmCurso(id);
            return curso == null ? NotFound() : Ok(curso); 
        }

        [HttpPost]
        public IActionResult IncluirCurso([FromBody] CursoDto cursoDto)
        {
            if (cursoDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var curso = _incluirCursoUseCase.IncluirCurso(cursoDto.Nome, cursoDto.Descricao, cursoDto.DataInicio, cursoDto.IdProfessor);

            if (curso != null)
            {
                return Ok(curso);
            }
            else
            {
                return BadRequest("Falha na inclusão do Curso");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarCurso(int id, [FromBody] CursoAltDto cursoAltDto)
        {
            if (id == null || cursoAltDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var curso = _alterarCursoUseCase.AlterarCurso(id, cursoAltDto.Nome, cursoAltDto.Descricao, cursoAltDto.DataInicio, cursoAltDto.Ativo, cursoAltDto.IdProfessor);

            if (curso != null)
            {
                return Ok(curso);
            }
            else
            {
                return BadRequest("Falha na alteração do Curso");
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _excluirCursoUseCase.ExcluirCurso(id);

        }
    }
}
