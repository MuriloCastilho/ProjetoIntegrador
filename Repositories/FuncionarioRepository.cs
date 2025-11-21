using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Repositories {
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository {

        private readonly ProjetoIntegradorDbContext _dbcontext;

        public FuncionarioRepository(ProjetoIntegradorDbContext dbcontext) : base(dbcontext) {
            _dbcontext = dbcontext;
        }
    }
}
