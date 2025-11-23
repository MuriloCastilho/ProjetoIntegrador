using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reserva> CreateReserva(CreateReservaInput input)
        {
            var reserva = new Reserva
            {
                Date = input.Data.ToDateTime(input.Horario, DateTimeKind.Local),
                Pessoa = input.Pessoa,
                Telefone = input.Telefone,
                Email = input.Email,
                Nome = input.Nome,
            };

            await _unitOfWork.Reserva.AddAsync(reserva);
            await _unitOfWork.CompleteAsync();

            return reserva;
        }
    }
}
