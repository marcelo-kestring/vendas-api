# Vendas API

Este repositório contém a implementação do backend para a API de Vendas da empresa XPTO10. O projeto é desenvolvido em .NET 6 e segue princípios de Domain-Driven Design (DDD), com uma estrutura organizada para facilitar a manutenção e a escalabilidade.

## Estrutura do Projeto

A estrutura de pastas do projeto é a seguinte:


vendas-api/
└── VendasAPISolution/
    ├── VendasAPIBackend/
    │   ├── Backend/
    │   └── BackendTests/
    └── Frontend/ (futuramente)


- **VendasAPIBackend**: Contém a implementação do backend da API de Vendas.
  - **Backend**: Código fonte principal do backend, incluindo controladores, serviços, repositórios e entidades de domínio.
  - **BackendTests**: Contém testes unitários e de integração para o backend.
- **Frontend**: (futuramente) Implementação do frontend em Angular para interagir com a API.

## Tecnologias Utilizadas

- **.NET 6**: Framework para o desenvolvimento do backend.
- **Entity Framework Core**: ORM utilizado para interagir com o banco de dados em memória.
- **Serilog**: Biblioteca de logging para registrar eventos e atividades.
- **xUnit**: Framework de testes para testes unitários.
- **FluentAssertions**: Biblioteca para asserções mais legíveis nos testes.
- **NSubstitute**: Biblioteca para criação de mocks nos testes.

## Configuração e Execução

### Pré-requisitos

- **.NET 6 SDK**: Certifique-se de que o .NET 6 SDK está instalado em sua máquina.

### Executando o Backend

1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/SEU_USUARIO/vendas-api.git
   cd vendas-api/VendasAPISolution/VendasAPIBackend

Restaurar Dependências:

dotnet restore


Executar o Backend:

dotnet run --project Backend

Executando os Testes

Testes Unitários:

dotnet test BackendTests --filter "Category=Unit"


Testes de Integração:

dotnet test BackendTests --filter "Category=Integration"

Futuras Implementações

Frontend Angular: Será desenvolvido para interagir com o backend e fornecer uma interface de usuário.


### Conclusão

Este `README.md` fornece uma visão geral clara do projeto, incluindo sua estrutura, tecnologias utilizadas, e instruções de configuração e execução. Isso deve ajudar outros desenvolvedores a entenderem rapidamente o projeto e começarem a trabalhar com ele. Se precisar de mais assistência ou ajustes, estou à disposição para ajudar!