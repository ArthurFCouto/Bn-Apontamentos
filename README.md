# 🧰 BN.Apontamentos - Backend

API desenvolvida com .NET 8, seguindo princípios modernos de arquitetura, com foco em organização, separação de responsabilidades (CQRS), extensibilidade e padronização de respostas. Ideal para aplicações corporativas com requisitos de validação, autenticação e manutenção limpa.

---

## 📦 Estrutura do Projeto

```
BN.Apontamentos.API              → Camada de apresentação (controllers e filtros)
BN.Apontamentos.Application      → Casos de uso (commands, queries, handlers, DTOs, validações)
BN.Apontamentos.Domain           → Regras de negócio, entidades e contratos
BN.Apontamentos.Infrastructure   → Persistência de dados (EF Core + Dapper), JWT, UnitOfWork
BN.Apontamentos.Service          → Implementações dos casos de uso (mediator handlers)
BN.Apontamentos.UnitTests        → Projeto de testes automatizados
```

---

## 🧱 Padrões e Conceitos Aplicados

### ✅ CQRS com MediatR

- Separação clara entre **commands** (ações que modificam dados) e **queries** (consultas).
- Uso de `IRequest<T>` e abstrações personalizadas como:
  - `CommandHandler<TCommand>`
  - `QueryHandler<TQuery, TResult>`
  - Interfaces `ICommandRequest`, `IQueryRequest<TResult>`

### ✅ Padronização de Respostas

Todas as respostas seguem a estrutura uniforme:

```csharp
Response<T> // ou Response
```

Com propriedades como:

- `Status` (Success, BadRequest, NotFound, etc.)
- `Message`
- `Data` (para responses com conteúdo)

### ✅ ActionFilter para tratar respostas

Filtro global (`ResponseActionFilter`) que converte automaticamente `Response` em `IActionResult`, com status HTTP apropriado.

### ✅ Validações com FluentValidation

- Validações separadas por classe (ex: `LoginUsuarioValidator`)
- Integração com a pipeline via `AddFluentValidationAutoValidation()`
- Classe base `BaseValidator<T>` para padronização de comportamento

### ✅ Mapeamento com Mapster

- Mapeamento entre DTOs e entidades com `TypeAdapterConfig`
- Registro automático via `AddApplicationMapster()`

### ✅ Autenticação JWT

- Configuração centralizada no `AddInfrastructure()`
- Validação automática via middleware e atributos `[Authorize]`

### ✅ Unit of Work

Interface `IUnitOfWork` para abstração de persistência:

```csharp
public interface IUnitOfWork
{
    Task AddAsync(object entity);
    Task<StatusCommit> CommitAsync();
    void RemoveAsync(object entity);
}
```

---

## 🚀 Como rodar o projeto localmente

### ✅ Pré-requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server LocalDB ou outro SQL compatível
- Ferramenta de REST (Postman, ThunderClient, etc.)

### ✅ Clonando o projeto

```bash
git clone https://github.com/seu-usuario/bn-apontamentos.git
cd bn-apontamentos
```

### ✅ Configuração de ambiente

Crie um arquivo `.env` (ou configure variáveis de ambiente manualmente):

```env
CONNECTION_STRINGS=Server=localhost;Database=BN.Apontamentos;Trusted_Connection=True;
JWT_SECRET=SuaChaveSuperSecretaAqui
JWT_ISSUER=BN
JWT_AUDIENCE=BNUsers
JWT_EXPIRATION_MINUTES=60
```

Ou configure as variáveis diretamente no `launchSettings.json` ou pelo terminal.

### ✅ Rodando a aplicação

```bash
cd BN.Apontamentos.API
dotnet run
```

Acesse:

```
https://localhost:5001/swagger
```

---

## 🧪 Rodando os testes

```bash
cd BN.Apontamentos.UnitTests
dotnet test
```

---

## 📌 Futuras Melhorias

- Integração com Identity Server
- Notificações por domínio (Domain Events)
- Integração com banco NoSQL para logs
- Cache com Redis
- Testes de integração com WebApplicationFactory

---

## 🤝 Contribuição

Pull requests são bem-vindos! Crie uma branch com sua feature, envie PR e vamos revisar juntos.

---

## 📄 Licença

Projeto privado - uso autorizado apenas para fins educacionais e internos da empresa BN.
