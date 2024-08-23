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

        public AlunoController(IAlunoRepository repository, IncluirAlunoUseCase incluirAlunoUseCase)
        {
            _repository = repository;
            _incluirAlunoUseCase = incluirAlunoUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            var alunos = _repository.SelecionarTudo();
            return alunos == null ? NotFound() : alunos;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _repository.SelecionarPorId(id);
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
            //return CreatedAtAction(nameof(Matricular), new { id = matricula.Id} , matricula);
        }

        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] AlunoDto alunoDto)
        {
            var alunoEntidade = _repository.SelecionarPorId(id);

            alunoEntidade.AlterarNome(alunoDto.Nome);

            _repository.Alterar(alunoEntidade);

            return alunoEntidade;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Excluir(id);

        }
    }
}
