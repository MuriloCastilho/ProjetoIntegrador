using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProjetoIntegrador.Dtos;
using ProjetoIntegrador.Entities;
using ProjetoIntegrador.Mappers;
using ProjetoIntegrador.Repositories.RepositoryBase;

namespace ProjetoIntegrador.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<PedidoHub> _hubContext;
        private readonly ProjetoIntegradorDbContext _context; // Necessário para consultas manuais complexas

        public PedidoService(
            IUnitOfWork unitOfWork,
            IHubContext<PedidoHub> hubContext,
            ProjetoIntegradorDbContext context)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
            _context = context;
        }

        public async Task<bool> CreatePedido(CriarPedidoDto dto)
        {
            // 1. Inicia a Transação (Tudo ou Nada)
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                // --- ETAPA 1: Salvar o Pedido ---
                var pedido = new Pedido
                {
                    MesaId = dto.MesaId,
                    Status = dto.Status,
                    Descricao = dto.Descricao,
                    // DataCriacao = DateTime.Now // Descomente se tiver essa coluna
                };

                await _unitOfWork.Pedido.AddAsync(pedido);
                await _unitOfWork.CompleteAsync(); // Gera o ID do Pedido

                // --- ETAPA 2: Salvar os Vínculos (Pedido -> Pratos) ---
                if (dto.IdPratos != null && dto.IdPratos.Any())
                {
                    foreach (var pratoId in dto.IdPratos)
                    {
                        // Criação manual do vínculo na tabela intermediária
                        var pedidoPrato = new PedidoPrato
                        {
                            PedidoId = pedido.Id,
                            PratoId = pratoId
                        };

                        // Adiciona direto no DbSet pois talvez você não tenha repo específico para isso
                        await _context.Set<PedidoPrato>().AddAsync(pedidoPrato);
                    }

                    await _context.SaveChangesAsync(); // Salva os vínculos
                }

                // --- ETAPA 3: Confirmar Transação ---
                await transaction.CommitAsync();


                // --- ETAPA 4: Notificar Cozinha (SignalR) ---
                try
                {
                    // Busca os dados completos manualmente para enviar o JSON bonito
                    var dadosParaCozinha = await MontarDtoParaCozinha(pedido.Id);

                    // Envia para todos conectados no Hub
                    await _hubContext.Clients.All.SendAsync("ReceberNovoPedido", dadosParaCozinha);
                }
                catch (Exception ex)
                {
                    // Se o SignalR falhar, apenas logamos. O pedido foi salvo, isso é o que importa.
                    Console.WriteLine($"Erro ao notificar cozinha: {ex.Message}");
                }

                return true;
            }
            catch (Exception)
            {
                // Se deu erro em qualquer etapa do banco, desfaz tudo.
                await transaction.RollbackAsync();
                throw;
            }
        }

        // --- MÉTODO AUXILIAR PARA BUSCAR DADOS SEM RELACIONAMENTO ---
        private async Task<PedidoCozinhaDto> MontarDtoParaCozinha(long pedidoId)
        {
            // 1. Busca o Pedido básico
            var pedido = await _unitOfWork.Pedido.GetByIdAsync(pedidoId);

            var dto = new PedidoCozinhaDto
            {
                Id = pedido.Id,
                MesaId = pedido.MesaId,
                Descricao = pedido.Descricao,
                DataHora = DateTime.Now
            };

            // 2. Busca IDs dos Pratos vinculados a este pedido
            // (SQL: Select PratoId from PedidoPratos where PedidoId = X)
            var idsPratos = await _context.Set<PedidoPrato>()
                                          .Where(pp => pp.PedidoId == pedidoId)
                                          .Select(pp => pp.PratoId)
                                          .ToListAsync();

            // 3. Busca os Pratos (Nome) baseados nos IDs
            var pratos = await _context.Pratos
                                       .Where(p => idsPratos.Contains(p.Id))
                                       .ToListAsync();

            // 4. Para cada prato, busca os ingredientes
            foreach (var prato in pratos)
            {
                var pratoDto = new PratoCozinhaDto
                {
                    Nome = prato.Nome,
                    Quantidade = 1 // Ajuste se tiver lógica de quantidade
                };

                // 4.1 Pega IDs dos ingredientes deste prato na tabela intermediária
                var idsIngredientes = await _context.PratoIngredientes
                                                    .Where(pi => pi.PratoId == prato.Id)
                                                    .Select(pi => pi.IngredienteId)
                                                    .ToListAsync();

                // 4.2 Pega os nomes dos ingredientes
                var nomesIngredientes = await _context.Ingredientes
                                                      .Where(i => idsIngredientes.Contains(i.Id))
                                                      .Select(i => i.Nome)
                                                      .ToListAsync();

                pratoDto.Ingredientes = nomesIngredientes;
                dto.Pratos.Add(pratoDto);
            }

            return dto;
        }
    }
}
