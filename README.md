# AeCTest

**AeCTest** é uma aplicação web desenvolvida em C# utilizando ASP.NET MVC e .NET 8, com o propósito de permitir que usuários se autentiquem, gerenciem endereços e exportem dados para um arquivo CSV. O sistema integra com a API ViaCEP para buscar informações de endereços a partir de um CEP.

## Funcionalidades

- **Autenticação de Usuário:** Permite que usuários realizem login com credenciais seguras.
- **CRUD de Endereços:** Usuários podem adicionar, visualizar, editar e excluir endereços.
- **Integração com ViaCEP:** Busca automática de informações de endereço a partir do CEP.
- **Exportação de Dados:** Exporta os endereços salvos para um arquivo CSV.

## Estrutura do Projeto

O projeto é composto pelas seguintes camadas:

- **AeCTest.Web:** Contém a aplicação ASP.NET MVC com controllers e views.
- **AeCTest.Core:** Contém os modelos e interfaces de serviço.
- **AeCTest.Infra:** Contém a implementação dos repositórios e o `DbContext`.
- **AeCTest.Service:** Contém a lógica de negócios e serviços.
- **AeCTest.Tests:** Contém os testes unitários para a aplicação.

## Configuração e Execução

1. **Configuração do Banco de Dados:**

   - **Instalar o SQL Server** e criar um banco de dados.
   - **Configurar a String de Conexão:**

     No arquivo `appsettings.json`, adicione a string de conexão para o SQL Server:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
       }
     }
     ```

2. **Configuração do Projeto:**

   - **Restaurar Pacotes:**

     Execute o comando para restaurar pacotes NuGet:

     ```bash
     dotnet restore
     ```

   - **Aplicar Migrations:**

     Gere e aplique as migrations para o banco de dados:

     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

3. **Executar a Aplicação:**

   - **Iniciar o Servidor Web:**

     Execute o projeto para iniciar o servidor web:

     ```bash
     dotnet run --project AeCTest.Web
     ```

     A aplicação estará disponível em `http://localhost:5000` ou `https://localhost:5001`.


