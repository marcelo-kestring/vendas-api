using Vendas.Dominio.Entities;

namespace Vendas.Dominio.Services
{
    public interface IVendaService
    {
        Task<IEnumerable<Venda>> ObterTodasVendasAsync();
        Task<Venda> ObterVendaPorIdAsync(int id);
        Task CriarVendaAsync(Venda venda);
        Task AtualizarVendaAsync(Venda venda);
        Task DeletarVendaAsync(int id);
        Task CancelarItemAsync(int vendaId, int itemId);
    }
}
