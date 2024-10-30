using FluentAssertions;
using NSubstitute;
using Serilog;
using Vendas.Dominio.Entities;
using Vendas.Dominio.Repositories;
using Vendas.Dominio.Services;

namespace Vendas.UnitTests
{
    public class VendaServiceTests
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly ILogger _logger;
        private readonly IVendaService _vendaService;

        public VendaServiceTests()
        {
            _vendaRepository = Substitute.For<IVendaRepository>();
            _logger = Substitute.For<ILogger>();
            _vendaService = new VendaService(_vendaRepository, _logger);
        }

        [Fact]
        public async Task CriarVenda_DeveAdicionarVendaELogarEvento()
        {
            // Arrange
            var venda = new Venda { NumeroVenda = "12345", Itens = new List<ItemVenda>() };

            // Act
            await _vendaService.CriarVendaAsync(venda);

            // Assert
            await _vendaRepository.Received(1).CriarVendaAsync(venda);
            _logger.Received(1).Information("Evento: CompraCriada - Venda {NumeroVenda} criada.", venda.NumeroVenda);
        }

        [Fact]
        public async Task ObterTodasVendas_DeveRetornarListaDeVendas()
        {
            // Arrange
            var vendasEsperadas = new List<Venda>
            {
                new Venda { NumeroVenda = "12345" },
                new Venda { NumeroVenda = "67890" }
            };
            _vendaRepository.ObterTodasVendasAsync().Returns(vendasEsperadas);

            // Act
            var vendas = await _vendaService.ObterTodasVendasAsync();

            // Assert
            vendas.Should().BeEquivalentTo(vendasEsperadas);
        }

        [Fact]
        public async Task ObterVendaPorId_DeveRetornarVendaQuandoExistir()
        {
            // Arrange
            var vendaEsperada = new Venda { Id = 1, NumeroVenda = "12345" };
            _vendaRepository.ObterVendaPorIdAsync(1).Returns(vendaEsperada);

            // Act
            var venda = await _vendaService.ObterVendaPorIdAsync(1);

            // Assert
            venda.Should().BeEquivalentTo(vendaEsperada);
        }

        [Fact]
        public async Task ObterVendaPorId_DeveRetornarNuloQuandoNaoExistir()
        {
            // Arrange
            _vendaRepository.ObterVendaPorIdAsync(1).Returns((Venda)null);

            // Act
            var venda = await _vendaService.ObterVendaPorIdAsync(1);

            // Assert
            venda.Should().BeNull();
        }

        [Fact]
        public async Task AtualizarVenda_DeveLogarEvento()
        {
            // Arrange
            var venda = new Venda { Id = 1, NumeroVenda = "12345" };

            // Act
            await _vendaService.AtualizarVendaAsync(venda);

            // Assert
            await _vendaRepository.Received(1).AtualizarVendaAsync(venda);
            _logger.Received(1).Information("Evento: CompraAlterada - Venda {NumeroVenda} atualizada.", venda.NumeroVenda);
        }

        [Fact]
        public async Task DeletarVenda_DeveLogarEvento()
        {
            // Arrange
            var vendaId = 1;
            var venda = new Venda { Id = vendaId, NumeroVenda = "12345" };
            _vendaRepository.ObterVendaPorIdAsync(vendaId).Returns(venda);

            // Act
            await _vendaService.DeletarVendaAsync(vendaId);

            // Assert
            await _vendaRepository.Received(1).DeletarVendaAsync(vendaId);
            _logger.Received(1).Information("Evento: CompraCancelada - Venda {NumeroVenda} cancelada.", venda.NumeroVenda);
        }

        [Fact]
        public async Task CancelarItem_DeveLogarEvento()
        {
            // Arrange
            var vendaId = 1;
            var itemId = 1;
            var venda = new Venda
            {
                Id = vendaId,
                NumeroVenda = "12345",
                Itens = new List<ItemVenda>
                {
                    new ItemVenda { Id = itemId, ProdutoId = "P001", Cancelado = false }
                }
            };
            _vendaRepository.ObterVendaPorIdAsync(vendaId).Returns(venda);

            // Act
            await _vendaService.CancelarItemAsync(vendaId, itemId);

            // Assert
            _logger.Received(1).Information("Evento: ItemCancelado - Item {ItemId} da Venda {NumeroVenda} cancelado.", itemId, venda.NumeroVenda);
        }
    }
}