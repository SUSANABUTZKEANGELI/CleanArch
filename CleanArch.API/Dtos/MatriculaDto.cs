using CleanArch.Domain.Entities.Enums;

namespace CleanArch.API.Dtos
{
    public class MatriculaDto
    {
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public StatusMatricula StatusMatricula { get; set; }
    }
}