namespace ProjetoIntegrador.Dtos
{
    public class PedidoCozinhaDto
    {
        public long Id { get; set; }
        public long MesaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public List<PratoCozinhaDto> Pratos { get; set; } = new List<PratoCozinhaDto>();
    }
}
