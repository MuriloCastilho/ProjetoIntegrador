using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories.RepositoryBase;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("/api/web/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoService _pedidoService;

        public PedidoController(IUnitOfWork unitOfWork, IPedidoService pedidoService)
        {
            _unitOfWork = unitOfWork;
            _pedidoService = pedidoService;
        }

        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> CriarPedido(CriarPedidoDto dto)
        {
            try
            {
                // Chama o serviço que contém a lógica de banco + signalR
                var sucesso = await _pedidoService.CreatePedido(dto);

                if (sucesso)
                {
                    return Ok(new { mensagem = "Pedido criado e enviado para a cozinha com sucesso!" });
                }
                else
                {
                    return BadRequest("Não foi possível criar o pedido.");
                }
            }
            catch (Exception ex)
            {
                // Logar o erro aqui seria o ideal
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
