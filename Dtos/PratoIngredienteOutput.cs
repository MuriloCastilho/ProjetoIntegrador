using ProjetoIntegrador.Entities;

namespace ProjetoIntegrador.Dtos
{
    public class PratoIngredienteOutput
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
