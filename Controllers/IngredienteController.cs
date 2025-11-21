using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories.RepositoryBase;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("api/web/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;
        private readonly IUnitOfWork _unitOfWork;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpPost]
        [Route("cria-ingrediente")]
        public async Task<IActionResult> CreateIngrediente(CreateIngredienteInput input)
        {
            var ingrediente = await _ingredienteService.CreateIngrediente(input);

            if (ingrediente == null)
                return BadRequest("Erro ao cadastrar ingrediente");

            return Ok("Ingrediente cadastrado com sucesso");
        }

        [HttpGet]
        [Route("busca-ingrediente")]
        public async Task<IActionResult> GetIngrediente(long id)
        {
            var ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(id);

            return Ok(ingrediente);
        }

        [HttpPut]
        [Route("atualiza-ingrediente")]
        public async Task<IActionResult> UpdateIngrediente(UpdateIngredientes update)
        {
            var ingrediente = await _ingredienteService.UpdateIngrediente(update);

            return Ok(ingrediente);
        }
    }
}
