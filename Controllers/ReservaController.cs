using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories.RepositoryBase;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("api/web/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly IUnitOfWork _unitOfWork;

        public ReservaController(IReservaService reservaService, IUnitOfWork unitOfWork)
        {
            _reservaService = reservaService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("cria")]
        public async Task<IActionResult> CreateReserva([FromBody] CreateReservaInput input)
        {
            var reserva = await _reservaService.CreateReserva(input);
            return Ok(reserva);
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> GetAllReserva()
        {
            var reservas = await _unitOfWork.Reserva.GetAllAsync();
            return Ok(reservas);
        }

        [HttpDelete]
        [Route("deleta")]
        public async Task<IActionResult> DeleteReserva([FromQuery] long id)
        {
            var reserva = await _unitOfWork.Reserva.GetByIdAsync(id);

            if (reserva == null)
            {
                return NotFound("Reserva não encontrada.");
            }

            _unitOfWork.Reserva.Delete(reserva);

            await _unitOfWork.CompleteAsync();

            return Ok("Reserva deletada com sucesso");
        }
    }
}
