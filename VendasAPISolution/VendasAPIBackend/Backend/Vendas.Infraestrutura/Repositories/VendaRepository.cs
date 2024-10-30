using Microsoft.EntityFrameworkCore;
using Vendas.Dominio.Entities;
using Vendas.Dominio.Repositories;
using Vendas.Infraestrutura.Data;

namespace Vendas.Infraestrutura.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _context;

        public VendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venda>> ObterTodasVendasAsync()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task<Venda> ObterVendaPorIdAsync(int id)
        {
            return await _context.Vendas.FindAsync(id);
        }

        public async Task CriarVendaAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarVendaAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarVendaAsync(int id)
        {
            var venda = await ObterVendaPorIdAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }
    }
}