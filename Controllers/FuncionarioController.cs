using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Repositories;
using ProjetoIntegrador.Service;

namespace ProjetoIntegrador.Controllers 
    {
    [ApiController]
    [Route("api/web/[controller]")]
    public class FuncionarioController : ControllerBase {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IFuncionarioService funcionarioService) {
            _funcionarioRepository = funcionarioRepository;
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        [Route("cria-funcionario")]
        public async Task<bool> CreateFuncionario(FuncionarioInput input) {
            var repositorio = await _funcionarioService.CreatFuncionario();

            if (repositorio == false)
                throw new Exception("Funcionario não criado");

            return true;
        }
    }
}