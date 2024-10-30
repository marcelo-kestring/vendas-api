using Serilog;
using Vendas.Dominio.Entities;
using Vendas.Dominio.Repositories;

namespace Vendas.Dominio.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly ILogger _logger;

        public VendaService(IVendaRepository vendaRepository, ILogger logger)
        {
            _vendaRepository = vendaRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Venda>> ObterTodasVendasAsync()
        {
            return await _vendaRepository.ObterTodasVendasAsync();
        }

        public async Task<Venda> ObterVendaPorIdAsync(int id)
        {
            return await _vendaRepository.ObterVendaPorIdAsync(id);
        }

        public async Task CriarVendaAsync(Venda venda)
        {
            await _vendaRepository.CriarVendaAsync(venda);
            _logger.Information("Evento: CompraCriada - Venda {NumeroVenda} criada.", venda.NumeroVenda);
        }

        public async Task AtualizarVendaAsync(Venda venda)
        {
            await _vendaRepository.AtualizarVendaAsync(venda);
            _logger.Information("Evento: CompraAlterada - Venda {NumeroVenda} atualizada.", venda.NumeroVenda);
        }

        public async Task DeletarVendaAsync(int id)
        {
            var venda = await _vendaRepository.ObterVendaPorIdAsync(id);
            if (venda != null)
            {
                await _vendaRepository.DeletarVendaAsync(id);
                _logger.Information("Evento: CompraCancelada - Venda {NumeroVenda} cancelada.", venda.NumeroVenda);
            }
        }

        public async Task CancelarItemAsync(int vendaId, int itemId)
        {
            var venda = await _vendaRepository.ObterVendaPorIdAsync(vendaId);
            if (venda != null)
            {
                var item = venda.Itens.FirstOrDefault(i => i.Id == itemId);
                if (item != null && !item.Cancelado)
                {
                    item.Cancelado = true;
                    await _vendaRepository.AtualizarVendaAsync(venda);
                    _logger.Information("Evento: ItemCancelado - Item {ItemId} da Venda {NumeroVenda} cancelado.", itemId, venda.NumeroVenda);
                }
            }
        }
    }
}