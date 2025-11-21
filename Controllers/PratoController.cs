using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("api/web/[controller]")]
    public class PratoController : ControllerBase
    {
        private readonly IPratoService _pratoService;

        public PratoController(IPratoService pratoService)
        {
            _pratoService = pratoService;
        }


        [HttpPost]
        [Route("cria-prato")]
        public async Task<IActionResult> CreatePrato(CreatePratoInput input)
        {
            var prato = await _pratoService.CreatePrato(input);

            return Ok(prato);
        }
    }
}
