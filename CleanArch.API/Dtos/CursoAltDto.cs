namespace CleanArch.API.Dtos
{
    public class CursoAltDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Ativo { get; set; }
        public int IdProfessor { get; set; }
    }
}