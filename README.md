# Sistema de Gerenciamento de Cultivos, Insumos e Vendas

Este é um sistema de gerenciamento de **cultivos, insumos e vendas**, com funcionalidades de cadastro, edição e exclusão de registros. O sistema foi desenvolvido utilizando ASP.NET Core com MVC, Entity Framework Core, e Razor Pages.

## Funcionalidades

1. **Cadastro de Cultivos e Insumos**: Permite registrar informações sobre cultivos e insumos, como nome, preço, fornecedor, etc.
2. **Edição de Cultivos e Insumos**: Permite editar os dados dos cultivos e insumos previamente cadastrados.
3. **Exclusão de Cultivos e Insumos**: Permite excluir cultivos e insumos após uma confirmação de exclusão.
4. **Cadastro de Vendas**: Permite registrar informações sobre vendas realizadas, como cliente, produto, quantidade, valor e forma de pagamento.
5. **Edição de Vendas**: Permite editar as informações de vendas registradas.
6. **Exclusão de Vendas**: Permite excluir vendas após confirmação.

## Estrutura do Projeto

### Pastas principais

- **Controllers**: Contém as lógicas de controle para as ações do usuário.
- **Models**: Define os modelos de dados que são usados no sistema (e.g., `CultivosEInsumos`, `Vendas`).
- **Views**: Contém as páginas da interface de usuário, com arquivos Razor para renderizar as páginas HTML.
- **Services**: Contém a lógica de serviços, como a manipulação dos dados e a comunicação com o banco de dados.

### Banco de Dados

O sistema utiliza o **Entity Framework Core** para comunicação com o banco de dados, e os seguintes modelos de dados são utilizados:

- **CultivosEInsumos**

  - Id
  - CultivoId
  - Cultivo
  - InsumoId
  - Insumo
  - FornecedorId
  - Fornecedor
  - Price

- **Vendas**
  - Id
  - Cliente
  - Produto
  - Quantidade
  - Valor
  - FormaDePagamento

### Configuração do Banco de Dados

Para a configuração inicial do banco de dados, foram utilizadas as migrações do Entity Framework Core. Siga os passos abaixo para configurar o banco de dados em sua máquina local:

1. Crie o banco de dados executando as migrações:

   ```bash
   dotnet ef migrations add Inicial
   dotnet ef database update
   ```
