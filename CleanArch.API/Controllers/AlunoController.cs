using CleanArch.API.Dtos;
using CleanArch.Data.UseCases;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
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
            if (alunoDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var aluno = _incluirAlunoUseCase.IncluirAluno(alunoDto.Nome, alunoDto.Endereco, alunoDto.Email);

            if (aluno != null)
            {
                return Ok(aluno);
            }
            else
            {
                return BadRequest("Falha na inclusão do aluno");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarAluno(int id, [FromBody] AlunoAltDto alunoAltDto)
        {
            if (id == null || alunoAltDto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var aluno = _alterarAlunoUseCase.AlterarAluno(id, alunoAltDto.Nome, alunoAltDto.Endereco, alunoAltDto.Email, alunoAltDto.Ativo);

            if (aluno != null)
            {
                return Ok(aluno);
            }
            else
            {
                return BadRequest("Falha na alteração do aluno");
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _excluirAlunoUseCase.ExcluirAluno(id);

        }
    }
}
