using Microsoft.EntityFrameworkCore;
using Vendas.Dominio.Entities;

namespace Vendas.Infraestrutura.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Set<Venda>().Any())
            {
                return;
            }

            var vendas = new List<Venda>
            {
                new Venda
                {
                    Id = 1,
                    NumeroVenda = "001",
                    Itens = new List<ItemVenda>
                    {
                        new ItemVenda { ProdutoId = "P001", Quantidade = 2, ValorUnitario = 10.00m, Desconto = 0, ValorTotal = 20.00m },
                        new ItemVenda { ProdutoId = "P002", Quantidade = 1, ValorUnitario = 15.00m, Desconto = 0, ValorTotal = 15.00m }
                    },
                    Cancelada = false
                },
                new Venda
                {
                    Id = 2,
                    NumeroVenda = "002",
                    Itens = new List<ItemVenda>
                    {
                        new ItemVenda { ProdutoId = "P003", Quantidade = 3, ValorUnitario = 5.00m, Desconto = 0, ValorTotal = 15.00m }
                    },
                    Cancelada = false
                },
                new Venda
                {
                    Id = 3,
                    NumeroVenda = "003",
                    Itens = new List<ItemVenda>
                    {
                        new ItemVenda { ProdutoId = "P004", Quantidade = 4, ValorUnitario = 5.00m, Desconto = 0, ValorTotal = 7.00m }
                    },
                    Cancelada = true
                }
            };

            context.Set<Venda>().AddRange(vendas);
            context.SaveChanges();
        }
    }
}
