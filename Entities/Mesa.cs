using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Entities
{
    public class Mesa
    {
        [Key]
        public long Id { get; set; }

        public string Nome { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public DateTime InicioAtendimento { get; set; }

        public DateTime FinalAtendimento { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CustoTotal { get; set; }
    }
}