using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("api/web/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IMesaService _mesaService;

        public MesaController(IMesaRepository mesaRepository, IMesaService mesaService)
        {
            _mesaRepository = mesaRepository;
            _mesaService = mesaService;
        }

        [HttpPost]
        [Route("cria-mesa")]
        public async Task<bool> CreateMesa(MesaInput input)
        {
            var repositorio = await _mesaService.CreatMesa();

            if (repositorio == false)
                throw new Exception("Mesa não criada");

            return true;
        }
    }
}
