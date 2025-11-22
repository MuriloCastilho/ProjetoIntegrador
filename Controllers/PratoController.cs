using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("api/web/[controller]")]
    public class PratoController : ControllerBase
    {
        private readonly IPratoService _pratoService;
        private readonly IPratoRepository _pratoRepository;

        public PratoController(IPratoService pratoService, IPratoRepository pratoRepository)
        {
            _pratoService = pratoService;
            _pratoRepository = pratoRepository;
        }


        [HttpPost]
        [Route("cria-prato")]
        public async Task<IActionResult> CreatePrato(CreatePratoInput input)
        {
            var prato = await _pratoService.CreatePrato(input);

            return Ok(prato);
        }

        [HttpDelete]
        [Route("deleta")]
        public async Task<IActionResult> DeletePrato(long id)
        {
            await _pratoService.DeletePrato(id);

            return Ok($"Prato {id} foi deletado com sucesso");
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> GetListPratos()
        {
            var list = await _pratoRepository.GetAllPratoIngrediente();

            return Ok(list);
        }
    }
}
