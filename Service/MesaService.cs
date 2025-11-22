using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Service
{
    public class MesaService : IMesaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProjetoIntegradorDbContext _dbcontext;

        public MesaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*
        public async Task<bool> CreateMesa()
        {
            var mesa = new Mesa();
            {

            };

            await _unitOfWork.Mesas.AddAsync(mesa);
            await _unitOfWork.CompleteAsync();

            return true;
        }*/

        public async Task<bool> CreateMesa(MesaInput input) {
            try {
                var mesa = new Mesa {
                    Nome = input.Nome,
                    Pedidos = input.Pedidos,
                    InicioAtendimento = input.InicioAtendimento,
                    FinalAtendimento = input.FinalAtendimento
                };

                await _unitOfWork.Mesas.AddAsync(mesa);
                await _unitOfWork.CompleteAsync();

                return true;
            } catch (DbUpdateException dbEx) {
                return false;
            }
        }

        public async Task<Mesa> GetMesa(long id) {
            return await _dbcontext.Mesas.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

    }
}
