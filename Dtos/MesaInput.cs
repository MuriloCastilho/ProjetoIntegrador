using ProjetoIntegrador.Entities;

namespace ProjetoIntegrador.Dtos
{
    public class MesaInput
    {
        public string Nome {  get; set; }
        public List<Pedido> Pedidos { get; set; }
        public DateTime InicioAtendimento { get; set; }
        public DateTime FinalAtendimento { get; set; }
    }
}
