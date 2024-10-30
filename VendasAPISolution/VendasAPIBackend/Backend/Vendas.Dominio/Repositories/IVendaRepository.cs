using Vendas.Dominio.Entities;

namespace Vendas.Dominio.Repositories
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> ObterTodasVendasAsync();
        Task<Venda> ObterVendaPorIdAsync(int id);
        Task CriarVendaAsync(Venda venda);
        Task AtualizarVendaAsync(Venda venda);
        Task DeletarVendaAsync(int id);
    }
}