using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Service
{
    public class MesaService : IMesaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MesaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatMesa()
        {
            var mesa = new Mesa();
            {

            };

            await _unitOfWork.Mesas.AddAsync(mesa);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
