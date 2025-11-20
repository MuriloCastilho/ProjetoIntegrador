using ProjetoIntegrador.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Entities
{
    public class Pedido
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public List<Prato> Pratos { get; set; }
        public long MesaId { get; set; }
        public StatusPedidoEnum Status { get; set; }
    }
}
