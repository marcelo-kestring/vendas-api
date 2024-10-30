# Vendas API

Este repositório contém a implementação do backend para a API de Vendas da empresa XPTO10. O projeto é desenvolvido em .NET 6 e segue princípios de Domain-Driven Design (DDD), com uma estrutura organizada para facilitar a manutenção e a escalabilidade.

## Estrutura do Projeto

A estrutura de pastas do projeto é a seguinte:


- vendas-api/
  - VendasAPISolution/
    - VendasAPIBackend/

Sendo assim, as pastas internas VendasAPIBackend tem a seguinte separação e propósitos:

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
- **Visual Studio 2022**: Certifique-se de ter o Visual Studio 2022 instalado com as cargas de trabalho do .NET.

### Executando o Backend no Visual Studio

1. **Clone o Repositório**:
   - Abra o Visual Studio.
   - Selecione **"Clone a repository"** na tela inicial.
   - Insira a URL do repositório: `https://github.com/SEU_USUARIO/vendas-api.git` e clique em **"Clone"**.

2. **Abrir a Solução**:
   - Navegue até a pasta `vendas-api/VendasAPISolution` e abra o arquivo `VendasAPISolution.sln`.

3. **Restaurar Dependências**:
   - No Visual Studio, vá para **"Build" > "Restore NuGet Packages"** para restaurar todas as dependências do projeto.

4. **Executar o Backend**:
   - No **Solution Explorer**, clique com o botão direito no projeto `VendasAPIBackend` e selecione **"Set as Startup Project"**.
   - Pressione **F5** ou clique em **"Start"** para compilar e executar o projeto. Isso iniciará o servidor e a API estará disponível para receber requisições.

### Verificando a Execução da Aplicação

- **Swagger UI**: Após iniciar a aplicação, abra um navegador da web e acesse `http://localhost:5000/swagger` (ou a porta configurada) para acessar a interface do Swagger. O Swagger fornece uma interface gráfica para visualizar e testar os endpoints da API.
- **Testando Endpoints**: Use o Swagger para enviar requisições aos endpoints e verificar se estão funcionando conforme esperado. Você pode testar operações CRUD, como criar, ler, atualizar e excluir vendas.

### Executando os Testes no Visual Studio

1. **Testes Unitários e de Integração**:
   - Abra o **Test Explorer** no Visual Studio (**"Test" > "Test Explorer"**).
   - Clique em **"Run All"** para executar todos os testes.
   - Para executar testes específicos, selecione-os no **Test Explorer** e clique em **"Run"**.

## Futuras Implementações

- **Frontend Angular**: Será desenvolvido para interagir com o backend e fornecer uma interface de usuário.

