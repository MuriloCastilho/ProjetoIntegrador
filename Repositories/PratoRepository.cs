using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Repositories
{
    public class PratoRepository : Repository<Prato>, IPratoRepository
    {
        private readonly ProjetoIntegradorDbContext _dbcontext;

        public PratoRepository(ProjetoIntegradorDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<PratoIngredienteOutput>> GetAllPratoIngrediente()
        {
            var pratos = await _dbcontext.Pratos
            .Select(p => new PratoIngredienteOutput
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,

                Ingredientes = _dbcontext.Ingredientes
                    .Where(ingrediente =>
                        _dbcontext.PratoIngredientes
                            .Any(pi => pi.PratoId == p.Id && pi.IngredienteId == ingrediente.Id)
                    )
                    .ToList()
            })
            .ToListAsync();

            return pratos;
        }
    }
}
