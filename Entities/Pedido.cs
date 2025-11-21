using ProjetoIntegrador.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Entities
{
    public class Pedido
    {
        [Key]
        public long Id { get; set; }

        public long MesaId { get; set; }

        public StatusPedidoEnum Status { get; set; }

        public string Descricao { get; set; }
    }
}
