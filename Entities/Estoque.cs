using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Entities
{
    public class Estoque
    {
        [Key]
        public long Id { get; set; }
        public string Ingrediete { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }
    }
}
