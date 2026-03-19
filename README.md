# 📚 LibrarySystem – Backend System

<p align="left">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core" />
  <img src="https://img.shields.io/badge/EF%20Core-7A3E9D?style=for-the-badge" alt="EF Core" />
  <img src="https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" alt="MySQL" />
  <img src="https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=for-the-badge" alt="Status" />
</p>

## 🧩 Sobre o Projeto

O **LibrarySystem** é o backend de um sistema de gestão de bibliotecas. O objetivo é construir uma API robusta e segura que servirá como base para uma futura interface web completa. O foco atual está no desenvolvimento da **Core API**, garantindo que as operações fundamentais sigam boas práticas de mercado antes da implementação de regras mais complexas.

---

## 🛠️ Tecnologias Utilizadas

| Camada | Tecnologia |
|--------|------------|
| **Linguagem** | C# 12 (.NET 8) |
| **Framework** | ASP.NET Core 8 |
| **ORM** | Entity Framework Core 8 |
| **Banco de Dados** | MySQL 8.0 |
| **Mapeamento** | AutoMapper |
| **Documentação** | Swagger / OpenAPI |
| **IDE** | JetBrains Rider / Visual Studio 2022 |
| **Versionamento** | Git + GitHub |

---

## 🏗️ Arquitetura do Projeto

Para garantir que o projeto não seja apenas um "CRUD simples", estou aplicando uma **Clean Architecture simplificada** dentro de um único projeto. Isso significa que o código está organizado em camadas lógicas (pastas) que separam claramente as responsabilidades.

### 📁 Estrutura de Pastas (Planejamento Inicial)

<pre>
LibraryFlow.API/
├── Controllers/
│   ├── BooksController.cs
│   ├── AuthorsController.cs
│   ├── UsersController.cs
│   └── LoansController.cs
│
├── Domain/
│   └── Entities/
│       ├── Book.cs
│       ├── Author.cs
│       ├── User.cs
│       └── Loan.cs
│
├── Application/
│   ├── DTOs/
│   │   ├── BookDto.cs
│   │   ├── CreateBookDto.cs
│   │   ├── AuthorDto.cs
│   │   ├── CreateAuthorDto.cs
│   │   ├── UserDto.cs
│   │   ├── CreateUserDto.cs
│   │   ├── LoanDto.cs
│   │   └── CreateLoanDto.cs
│   ├── Interfaces/
│   │   ├── IBookRepository.cs
│   │   ├── IAuthorRepository.cs
│   │   ├── IUserRepository.cs
│   │   ├── ILoanRepository.cs
│   │   └── IUnitOfWork.cs
│   ├── Profiles/
│   │   └── MappingProfile.cs
│   └── Services/
│       ├── BookService.cs
│       ├── AuthorService.cs
│       ├── UserService.cs
│       └── LoanService.cs
│
├── Infrastructure/
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   └── Configurations/
│   │       ├── BookConfiguration.cs
│   │       ├── AuthorConfiguration.cs
│   │       ├── UserConfiguration.cs
│   │       └── LoanConfiguration.cs
│   └── Repositories/
│       ├── BookRepository.cs
│       ├── AuthorRepository.cs
│       ├── UserRepository.cs
│       └── LoanRepository.cs
│
├── Extensions/
│   └── ServiceExtensions.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
</pre>

### 🔍 Explicação das Camadas

- **Controllers**: Responsáveis por receber as requisições HTTP, chamar os serviços apropriados e retornar as respostas. Nunca acessam diretamente o banco de dados.
- **Domain**: Contém as **entidades** (classes que representam as tabelas do banco) e, futuramente, regras de negócio fundamentais. É o núcleo da aplicação.
- **Application**: Abriga a lógica de aplicação:
  - **DTOs**: Objetos que trafegam entre a API e o cliente. Protegem as entidades e controlam quais dados são expostos.
  - **Interfaces**: Contratos que definem o que a infraestrutura deve implementar (repositórios, serviços).
  - **Profiles**: Mapeamentos do AutoMapper (entidade ↔ DTO).
  - **Services**: Implementam as regras de negócio e orquestram repositórios.
- **Infrastructure**: Implementa o acesso a dados e outras dependências externas.
  - **Data**: `DbContext`, configurações do EF Core (Fluent API).
  - **Repositories**: Classes concretas que herdam das interfaces definidas na Application.
- **Extensions**: Centraliza a configuração de serviços (CORS, AutoMapper, DbContext, etc.) para manter o `Program.cs` limpo.

---

## 🗺️ Roadmap de Evolução

- [x] **Setup**: Configuração do ambiente, Entity Framework, Swagger e estrutura de pastas.
- [ ] **Fase 1**: CRUD completo com MySQL.
- [ ] **Fase 2**: Autenticação com ASP.NET Core Identity + JWT.
- [ ] **Fase 3**: Regras de negócio de empréstimos e devoluções.
- [ ] **Fase 4**: Frontend web e integração full-stack.
- [ ] **Fase 5**: Testes automatizados (unitários e de integração) e deploy.

---

## 🚀 Como executar o projeto localmente

## Pré-requisitos

- .NET 8 SDK
- MySQL 8.0 ou superior
- Git

## Passos

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/LibrarySystem.git
cd LibrarySystem/src/LibrarySystem.API
```

### 2. Configurar a string de conexão com User Secrets

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=LibrarySystemDb;User=root;Password=sua_senha;"
```

### 3. Aplicar as migrações

```bash
dotnet ef database update
```

### 4. Executar a API

```bash
dotnet run
```

### 5. Acessar a documentação Swagger

```text
https://localhost:5001/swagger
```

## 📌 Boas Práticas Aplicadas

- **DTOs em vez de entidades expostas:** toda comunicação com o cliente ocorre via Data Transfer Objects, evitando exposição desnecessária e ataques de over-posting.
- **Repositório genérico (futuro):** será implementado para abstrair operações comuns (CRUD) e facilitar testes.
- **AutoMapper:** reduz código repetitivo no mapeamento entre entidades e DTOs.
- **User Secrets:** mantém credenciais sensíveis fora do repositório.
- **Separação de responsabilidades:** cada camada tem uma função bem definida, preparando o terreno para uma futura separação em projetos independentes.

## 📖 Documentação do Aprendizado

Todas as decisões técnicas, padrões utilizados e desafios enfrentados estão sendo documentados no meu Notion (meu "segundo cérebro"). Isso garante que o conhecimento seja registrado e possa ser consultado posteriormente.

## 🤝 Contribuição

Este é um projeto pessoal com fins de estudo, mas sugestões e críticas construtivas são bem-vindas. Sinta-se à vontade para abrir uma issue ou enviar um pull request.

## 📄 Licença

Distribuído sob a licença MIT. Veja o arquivo `LICENSE` para mais informações.

## 👨‍💻 Autor

Desenvolvido por **Guilherme de Andrade Nascimento**  