
# 📋 BN.Apontamentos

Sistema SaaS simples para registro de apontamentos de cabos lançados em plantas de energia solar.

---

## 🔧 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- C# 12
- Entity Framework Core
- Dapper
- Mapster (mapeamento de objetos)
- MediatR (CQRS)
- FluentValidation
- JWT (JSON Web Token)
- SQL Server
- xUnit + FluentAssertions + Moq (Testes unitários)

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas com separação de responsabilidades:

```
├── Api                     → Endpoints, autenticação e middlewares
├── Application             → Commands, Queries, Responses, DTOs e validações
├── Domain                  → Entidades e regras de negócio
├── Infrastructure          → Configuração de banco de dados, EF Core, Dapper
├── Service                 → Serviços auxiliares como geração de tokens
├── UnitTests               → Testes unitários
```

---

## 🔐 Autenticação

Autenticação baseada em JWT.

As configurações de ambiente necessárias:

```env
JWT_SECRET=chave-secreta-aqui
JWT_ISSUER=BN.Apontamentos
JWT_AUDIENCE=BN.Apontamentos.Client
JWT_EXPIRATION_MINUTES=60
CONNECTION_STRINGS=Server=...;Database=...;Trusted_Connection=True;
```

---

## 🧪 Testes

Testes escritos com:

- xUnit
- FluentAssertions
- Moq
- Mapster for Unit Tests

Para rodar os testes:

```bash
dotnet test
```

---

## 📁 Módulos principais

### 🔹 Login de Usuário

- Endpoint: `POST /login`
- Payload:
```json
{
  "matricula": 12345678,
  "senha": "minhaSenhaSegura"
}
```

### 🔹 Apontamentos

- Tela de lançamentos com carregamento condicionado por “Plano de Corte” e “Circuito”
- Campos preenchidos automaticamente com base na consulta
- Cálculo automático do total lançado (diferença entre início e fim)

---

## 🔄 Mapeamento de Objetos

Utilizado `Mapster`. Configuração automática feita via:

```csharp
services.AddApplicationMapster();
```

Todos os mapeamentos registrados com implementações de `IRegister`.

---

## 📘 Validações

Utiliza `FluentValidation`, registrado no `Program.cs`:

```csharp
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<LoginUsuarioValidator>();
    });
```

---

## 🧠 Exemplos úteis

### 🔹 Mapping com Mapster

```csharp
entity.Adapt<ListarTrechoResponse>();
```

### 🔹 Validação customizada

```csharp
public class LoginUsuarioValidator : AbstractValidator<LoginUsuarioRequest>
{
    public LoginUsuarioValidator()
    {
        RuleFor(x => x.Matricula)
            .GreaterThan(9999999);
        RuleFor(x => x.Senha)
            .NotEmpty().MinimumLength(8);
    }
}
```

---

## 📌 Status

🚧 Projeto em desenvolvimento (MVP funcional em progresso)

---

## 📎 Observações

- O Entity Framework está configurado para **não excluir registros em cascata** (uso de `.OnDelete(DeleteBehavior.Restrict)`).
- A autenticação está configurada manualmente no método `AddInfrastructure`.

---

## 🤝 Contribuição

1. Clone o repositório
2. Crie sua branch
3. Faça suas alterações
4. Envie o pull request

---

## 📄 Licença

Projeto desenvolvido para fins didáticos e de uso interno. Licenciamento poderá ser definido posteriormente.

---
