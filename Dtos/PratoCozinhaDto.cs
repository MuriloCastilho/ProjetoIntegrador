namespace ProjetoIntegrador.Dtos
{
    public class PratoCozinhaDto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public List<string> Ingredientes { get; set; } = new List<string>();
    }
}
