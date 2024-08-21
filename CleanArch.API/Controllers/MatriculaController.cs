using CleanArch.API.Dtos;
using CleanArch.Data.UseCases;
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
        private readonly MatriculaUseCase _matriculaUseCase;

        public MatriculaController(IMatriculaRepository repository, MatriculaUseCase matriculaUseCase)
        {
            _repository = repository;
            _matriculaUseCase = matriculaUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Matricula>> Get()
        {
            var matriculas = _repository.SelecionarTudo();
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

            var matricula = _matriculaUseCase.Matricular(matriculaDto.IdCurso, matriculaDto.IdAluno);

            if (matricula != null)
            {
                return Ok(matricula);
            }
            else
            {
                return BadRequest("Falha na inclusão da matrícula");
            }
            //return CreatedAtAction(nameof(Matricular), new { id = matricula.Id} , matricula);
        }

        [HttpPut("{id}")]
        public Matricula Put(int id, [FromBody] MatriculaDto matriculaDto)
        {
            var matriculaEntidade = _repository.SelecionarPorId(id);

            matriculaEntidade.AlterarStatusMatricula(matriculaDto.StatusMatricula);

            _repository.Alterar(matriculaEntidade);

            return matriculaEntidade;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Excluir(id);

        }
    }
}
