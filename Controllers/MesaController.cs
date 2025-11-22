using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories.RepositoryBase;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers {
    [ApiController]
    [Route("api/web/[controller]")]
    public class MesaController : Controller {

        private readonly IMesaService _mesaService;
        private readonly IUnitOfWork _unitOfWork;

        public MesaController(IMesaService mesaService) {
            _mesaService = mesaService;
        }

        [HttpPost]
        [Route("cria-mesa")]
        public async Task<IActionResult> CreateMesa(MesaInput input) {
            var mesa = await _mesaService.CreateMesa(input);

            if (mesa == null)
                return BadRequest("Erro ao criar mesa");

            return Ok("Mesa criada com sucesso");
        }

        [HttpGet]
        [Route("busca-mesa")]
        public async Task<IActionResult> GetMesa(long id) {
            var mesa = await _unitOfWork.Mesas.GetByIdAsync(id);

            return Ok(mesa);
        }
    }
}