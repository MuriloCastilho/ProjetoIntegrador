using ProjetoIntegrador.Dtos;

namespace ProjetoIntegrador.Service
{
    public interface IMesaService
    {
        Task<bool> CreateMesa(MesaInput input);

    }
}
