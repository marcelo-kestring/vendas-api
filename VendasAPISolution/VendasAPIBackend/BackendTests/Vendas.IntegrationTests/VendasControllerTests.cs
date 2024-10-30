using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;
using System.Text.Json;
using Vendas.Dominio.Entities;

namespace Vendas.IntegrationTests
{
    public class VendasControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public VendasControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ObterTodasVendas_DeveRetornarListaDeVendas()
        {
            // Act
            var response = await _client.GetAsync("/api/vendas");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var vendas = JsonSerializer.Deserialize<List<Venda>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            vendas.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Get_ObterVendaPorId_DeveRetornarVendaQuandoExistir()
        {
            // Arrange
            var response = await _client.GetAsync("/api/vendas/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var venda = JsonSerializer.Deserialize<Venda>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            venda.Should().NotBeNull();
            venda.Id.Should().Be(1);
        }

        [Fact]
        public async Task Post_CriarVenda_DeveAdicionarNovaVenda()
        {
            // Arrange
            var novaVenda = new Venda
            {
                NumeroVenda = "003",
                Itens = new List<ItemVenda>
                {
                    new ItemVenda { ProdutoId = "P004", Quantidade = 5, ValorUnitario = 10.00m, Desconto = 0, ValorTotal = 50.00m }
                }
            };
            var content = new StringContent(JsonSerializer.Serialize(novaVenda), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/vendas", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var vendaCriada = JsonSerializer.Deserialize<Venda>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            vendaCriada.Should().NotBeNull();
            vendaCriada.NumeroVenda.Should().Be("003");
        }

        [Fact]
        public async Task Put_AtualizarVenda_DeveModificarVendaExistente()
        {
            // Arrange
            var vendaAtualizada = new Venda
            {
                Id = 2,
                NumeroVenda = "001-Atualizada",
                Itens = new List<ItemVenda>
                {
                    new ItemVenda { ProdutoId = "P001", Quantidade = 2, ValorUnitario = 10.00m, Desconto = 0, ValorTotal = 20.00m }
                }
            };
            var content = new StringContent(JsonSerializer.Serialize(vendaAtualizada), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/vendas/2", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var getResponse = await _client.GetAsync("/api/vendas/2");
            var getContent = await getResponse.Content.ReadAsStringAsync();
            var venda = JsonSerializer.Deserialize<Venda>(getContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            venda.NumeroVenda.Should().Be("001-Atualizada");
        }

        [Fact]
        public async Task Delete_DeletarVenda_DeveRemoverVendaExistente()
        {
            // Act
            var response = await _client.DeleteAsync("/api/vendas/3");

            // Assert
            response.EnsureSuccessStatusCode();
            var getResponse = await _client.GetAsync("/api/vendas/3");
            getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}