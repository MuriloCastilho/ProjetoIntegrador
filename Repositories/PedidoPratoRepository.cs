using ProjetoIntegrador.Database;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Repositories
{
    public class PedidoPratoRepository : Repository<PedidoPrato>, IPedidoPratoRepository
    {
        private readonly ProjetoIntegradorDbContext _dbcontext;

        public PedidoPratoRepository(ProjetoIntegradorDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
