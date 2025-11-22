using ProjetoIntegrador.Database;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly ProjetoIntegradorDbContext _dbcontext;

        public PedidoRepository(ProjetoIntegradorDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }


    }
}
