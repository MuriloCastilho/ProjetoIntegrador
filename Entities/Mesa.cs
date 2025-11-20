using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Entities
{
    public class Mesa
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public List<Pedido>? Pedidos { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CustoTotal { get; set; }
    }
}
