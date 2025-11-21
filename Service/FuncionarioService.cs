using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Service {
    public class FuncionarioService {
        private readonly IUnitOfWork _unitOfWork;
        public FuncionarioService(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatFuncionario() {
            var funcionario = new Funcionario {

            };

            await _unitOfWork.Funcionario.AddAsync(funcionario);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
