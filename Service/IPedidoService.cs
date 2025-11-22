using ProjetoIntegrador.Dtos;

namespace ProjetoIntegrador.Service
{
    public interface IPedidoService
    {
        Task<bool> CreatePedido(CriarPedidoDto dto);

    }
}
