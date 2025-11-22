using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Repositories
{
    public interface IPratoRepository : IRepository<Prato>
    {
        Task<List<PratoIngredienteOutput>> GetAllPratoIngrediente();

    }
}
