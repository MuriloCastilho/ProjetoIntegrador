using ProjetoIntegrador.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Entities
{
    public class Funcionario
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public FuncaoEnum Funcao { get; set; }
    }
}
