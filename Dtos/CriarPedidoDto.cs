using ProjetoIntegrador.Enums;

namespace ProjetoIntegrador.Dtos
{
    public class CriarPedidoDto
    {
        public long MesaId { get; set; }

        public StatusPedidoEnum Status { get; set; }

        public string Descricao { get; set; }
        public List<long> IdPratos { get; set; }
    }
}
