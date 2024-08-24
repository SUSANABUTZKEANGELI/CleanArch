namespace CleanArch.API.Dtos
{
    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime ApplicationInicio { get; set; }
        public int IdProfessor { get; set; }
    }
}